using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour {
	public ParkedCars parkedCars;

  public GameObject customerPrefab;

  public float startDelay = 1f;
  public float spawnDelay = 5f;

	void Start () {
		parkedCars = GetComponent<ParkedCars>();

	  StartCoroutine(SpawnCustomer());
	}

  IEnumerator SpawnCustomer() {
    yield return new WaitForSeconds(startDelay);
    while (true) {
      GameObject car = parkedCars.GetRandomParkedCar();

      if (car != null) {
        Car carComponent = car.GetComponent<Car>();

        GameObject customer = (GameObject) Instantiate(customerPrefab, transform.position, transform.rotation);
        customer.GetComponent<Customer>().SetID(carComponent.GetID());
        carComponent.customer = customer;
      }
      yield return new WaitForSeconds(spawnDelay);
    }
  }
}
