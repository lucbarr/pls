using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CarGenerator : MonoBehaviour {
  public Queue<String> availableIDS;
  public GameObject carPrefab;
  public const int MAXSIZE = 10;

  public float startDelay = 1f;
  public float spawnDelay = 1f;

  //CarQueue carQueue;

  void Start () {
    availableIDS = new Queue<String>();
    List<String> available = new List<String>();

    for (char i = 'A'; i <= 'Z'; i++) {
      for (char j = 'A'; j <= 'Z'; j++) {
        var builder = new StringBuilder();
        builder.Append(i);
        builder.Append(j);
        available.Add(builder.ToString());
      }
    }

    var rnd = new System.Random();
    available = available.OrderBy(item => rnd.Next()).ToList();

    foreach (var variable in available) {
      availableIDS.Enqueue(variable);
    }

    //carQueue = GetComponentInParent<CarQueue>();

    StartCoroutine(SpawnCar());
  }

  String getCar() {
    if (!availableIDS.Any()) return null;
    //if (carQueue.Count() >= MAXSIZE) return null;
    return availableIDS.Dequeue();
  }

  void removeCar(String id) {
    availableIDS.Enqueue(id);
  }

  IEnumerator SpawnCar() {
    yield return new WaitForSeconds(startDelay);
    while (true) {
      String newID = getCar();

      if (newID == null) continue;

      GameObject car = (GameObject) Instantiate(carPrefab, transform.position, transform.rotation);
      car.GetComponent<Car>().SetID(newID);
      Debug.Log("Car");

      //carQueue.AddCar(car);
      yield return new WaitForSeconds(spawnDelay);
    }
  }
}
