using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : MonoBehaviour {
  List<GameObject> carList;

  void Start() {
    carList = new List<GameObject>();
  }

  public GameObject GetCar() {
    if(carList.Count == 0)
      return null;
    return carList[0];
  }

  void OnDisable() {
    carList.Clear();
  }

  void OnTriggerEnter2D(Collider2D coll) {
    if (coll.CompareTag("Car") && !carList.Contains(coll.gameObject)) {
      carList.Add(coll.gameObject);
    }
  }

  void OnTriggerExit2D(Collider2D coll) {
    if (coll.CompareTag("Car") && carList.Contains(coll.gameObject)) {
      carList.Remove(coll.gameObject);
    }
  }
}
