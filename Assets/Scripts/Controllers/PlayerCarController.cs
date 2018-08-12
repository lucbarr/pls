using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour {
  bool driving;

  GameObject player;
  GameObject car;

  void Start() {
    player = GameObject.FindWithTag("Player");
  }

  void Update() {
    if (Input.GetKeyDown("space")) {
      if (driving) {
        player.transform.parent = null;
        player.SetActive(true);
        car.GetComponent<CarMovement>().enabled = false;

        if (car.GetComponent<Car>().deliveryReady) {
          Debug.Log("Entregando carro");
          Destroy(car);
        }
        car = null;

        driving = false;
      } else {
        car = player.GetComponent<CarInteraction>().GetCar();
        if (car) {
          player.transform.SetParent(car.transform);
          player.SetActive(false);
          car.GetComponent<CarMovement>().enabled = true;

          driving = true;
        }
      }
    }
  }
}
