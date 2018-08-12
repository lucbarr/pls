using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftQueue : MonoBehaviour {
  public CarQueue carQueue;
  public void OnTriggerExit2D(Collider2D car) {
    if (!car.gameObject.CompareTag("Car")) return;

    carQueue.RemoveCar();
  }
}
