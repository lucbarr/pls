using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour {
	public Text id;
	public Boolean deliveryReady;

	void Start () {
	}

	public String GetID() {
		return id.text;
	}

	public void SetID(String id_) {
		id.text = id_;
		deliveryReady = false;
	}
	
	void Update () {
	}

}
