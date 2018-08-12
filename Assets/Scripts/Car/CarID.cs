using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CarID : MonoBehaviour {
	public Text id;

	void Start () {
	}

	public String GetID() {
		return id.text;
	}

	public void SetID(String id_) {
		id.text = id_;
	}
	
	void Update () {
	}

}
