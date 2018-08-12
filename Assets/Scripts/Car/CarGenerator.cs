using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CarGenerator : MonoBehaviour {
  public Queue<String> availableIDS;
  public List<GameObject> carQueue;

  public GameObject carPrefab;
  public const int MAXSIZE = 10;

  public float startDelay = 1f;
  public float spawnDelay = 5f;

  void Start () {
    availableIDS = new Queue<String>();
    carQueue = new List<GameObject>();

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

    StartCoroutine(SpawnCar());
  }

  String GetCar() {
    if (!availableIDS.Any()) return null;
    if (carQueue.Count >= MAXSIZE) return null;

    return availableIDS.Dequeue();
  }

  void removeCar(String id) {
    availableIDS.Enqueue(id);
  }

  IEnumerator SpawnCar() {
    yield return new WaitForSeconds(startDelay);
    while (true) {
      String newID = GetCar();

      if (newID != null) {

        GameObject car = (GameObject) Instantiate(carPrefab, transform.position, transform.rotation);
        car.GetComponent<Car>().SetID(newID);
        carQueue.Add(car);
      }

      yield return new WaitForSeconds(spawnDelay);

    }
  }

  public void RemoveCarFromQueue(GameObject car) {
    carQueue.Remove(car);
  }
}
