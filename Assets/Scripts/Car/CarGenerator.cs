using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using UnityEditor;
using UnityEngine;

public class CarGenerator : MonoBehaviour {
	public Queue<String> availableIDS;
	private int queueSize;
	public GameObject carPrefab;
	public const int MAXSIZE = 10;

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
		if (!availableIDS.Any()) return null;
		if (GetComponentInParent<CarQueue>().Count() >= MAXSIZE) return null;
		return availableIDS.Dequeue();
	}
	void removeCar(String ID) {
		availableIDS.Enqueue(ID);
	}
	IEnumerator SpawnCar() {
		yield return new WaitForSeconds(5);
		while (true) {
			String newID = getCar();

			if (newID == null) continue;

			GameObject car = (GameObject) Instantiate(carPrefab, transform.position, transform.rotation);
			car.GetComponent<Car>().SetID(newID);
			car.GetComponent<CarAutoPilot>().enabled = true;

			GetComponentInParent<CarQueue>().AddCar(car);
			yield return new WaitForSeconds(5);
		}
	}
}
