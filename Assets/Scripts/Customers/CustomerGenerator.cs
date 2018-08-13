using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour {
	public ParkedCars parkedCars;

  public GameObject customerPrefab;

  public List<RuntimeAnimatorController> customerAnimators;

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

        int spriteId = UnityEngine.Random.Range(0,customerAnimators.Count);

        GameObject customer = (GameObject) Instantiate(customerPrefab, transform.position, transform.rotation);
        customer.GetComponent<Customer>().SetID(carComponent.GetID());
        customer.GetComponent<Customer>().GetComponent<CustomerAutoPilot>().anim = new Animator();
        customer.GetComponent<Customer>().GetComponent<CustomerAutoPilot>().StartAnimator();
        customer.GetComponent<Customer>().GetComponent<CustomerAutoPilot>().anim.runtimeAnimatorController = customerAnimators[spriteId];
        carComponent.customer = customer;
      }
      yield return new WaitForSeconds(spawnDelay);
    }
  }
}
