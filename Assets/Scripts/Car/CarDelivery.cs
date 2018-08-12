using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDelivery: MonoBehaviour {
  public void Start() {
  }

  public void OnTriggerEnter2D(Collider2D car) {
    if (!car.CompareTag("Car")) return;
    car.GetComponent<Car>().deliveryReady = true;
  }
  public void OnTriggerExit2D(Collider2D car) {
    if (!car.CompareTag("Car")) return;
    car.GetComponent<Car>().deliveryReady = false;
  }
}
