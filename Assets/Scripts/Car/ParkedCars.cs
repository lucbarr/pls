using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParkedCars : MonoBehaviour {
	public List<GameObject> parkedCars;

	public float waitDelay = 10;

	void Start () {
		parkedCars = new List<GameObject>();
	}

	public GameObject GetRandomParkedCar() {
		if (!parkedCars.Any()) return null;

    var rnd = new System.Random();
		int random = rnd.Next()%parkedCars.Count;
		GameObject car = parkedCars[random];
		parkedCars.RemoveAt(random);

		return car;
	}

	public void Add(GameObject car) {
		StartCoroutine(WaitAndAddCar(car));
	}

	public IEnumerator WaitAndAddCar(GameObject car) {
    yield return new WaitForSeconds(waitDelay);
		parkedCars.Add(car);
		yield return null;
	}
}
