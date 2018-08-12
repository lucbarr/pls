using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class CarGenerator : MonoBehaviour {
	public Queue<String> availableIDS;
	private int queueSize;
	public GameObject carPrefab;

	void Start () {
		availableIDS = new Queue<string>();
		List<String> available = new List<String>();

		for (char i = 'A'; i <= 'Z'; i++) {
			for (char j = 'A'; j <= 'Z'; j++) {
		var builder = new StringBuilder();
				builder.Append(i);
				builder.Append(j);
				available.Add(builder.ToString());
			}
		}

		var rnd = new System.Random();
		available = available.OrderBy(item => rnd.Next()).ToList();

		foreach (var variable in available) {
			availableIDS.Enqueue(variable);
		}

		StartCoroutine(SpawnCar());
	}
	
	void Update () {

	}

	String getCar() {
		if (availableIDS.Count() == 0) return null;
		return availableIDS.Dequeue();
	}
	void removeCar(String ID) {
		availableIDS.Enqueue(ID);
	}
	IEnumerator SpawnCar() {
		while (true) {
			String newID = getCar();

			if (newID == null) continue;

			GameObject car = (GameObject) Instantiate(carPrefab, transform.position, transform.rotation);
			car.GetComponent<Car>().SetID(newID);

			GetComponentInParent<CarQueue>().AddCar(car);
			yield return new WaitForSeconds(20);
		}
	}
}
