using UnityEngine;

public class PlayerCarController : MonoBehaviour {
  bool driving;

  CarGenerator carGenerator;
  ParkedCars parkedCars;
  GameObject player;
  GameObject car;

  void Start() {
    player = GameObject.FindWithTag("Player");
    carGenerator = GameObject.FindWithTag("CarGenerator").GetComponent<CarGenerator>();
    parkedCars = GameObject.FindWithTag("CustomerGenerator").GetComponent<ParkedCars>();
  }

  void Update() {
    if (Input.GetKeyDown("space")) {
      if (driving) {
        player.transform.parent = null;
        player.SetActive(true);

        Car carComponent = car.GetComponent<Car>();

        car.GetComponent<CarMovement>().enabled = false;

        if (carComponent.deliveryReady && carComponent.customer != null) {
          Destroy(carComponent.customer);
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
            parkedCars.Add(car);
          }

          driving = true;
        }
      }
    }
  }
}
