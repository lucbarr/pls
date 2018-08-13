using UnityEngine;

public class PlayerCarController : MonoBehaviour {
  bool driving;

  CarGenerator carGenerator;
  GameObject player;
  GameObject car;

  void Start() {
    player = GameObject.FindWithTag("Player");
    carGenerator = GameObject.FindWithTag("CarGenerator").GetComponent<CarGenerator>();
  }

  void Update() {
    if (Input.GetKeyDown("space")) {
      if (driving) {
        player.transform.parent = null;
        player.SetActive(true);

        car.GetComponent<CarMovement>().enabled = false;

        if (car.GetComponent<Car>().deliveryReady) {
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
          if (car.GetComponent<CarAutoPilot>().enabled) {
            car.GetComponent<CarAutoPilot>().enabled = false;
            carGenerator.RemoveCarFromQueue(car);
          }


          driving = true;
        }
      }
    }
  }
}
