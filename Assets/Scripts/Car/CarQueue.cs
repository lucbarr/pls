using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CarQueue : MonoBehaviour {
  public Queue<GameObject> Cars;

  void Start () {
    Cars = new Queue<GameObject>();
  }

  public void AddCar(GameObject car) {
    Cars.Enqueue(car);
  }

  public void RemoveCar() {
    var car = Cars.Dequeue();
  }

  public int Count() {
    return Cars.Count;
  }
}
