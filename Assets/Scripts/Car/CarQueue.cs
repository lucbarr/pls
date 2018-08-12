using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CarQueue : MonoBehaviour {

	public Queue<GameObject> Cars;
	public Transform StartQueue;

	void Start () {
		Cars = new Queue<GameObject>();
	}

	public void Update() {
	}

	public void AddCar(GameObject car) {
		Cars.Enqueue(car);
	}
	
	public void RemoveCar() {
		var car = Cars.Dequeue();
		//Debug.Log("teste:  " +  Cars.Count);
	}
}
