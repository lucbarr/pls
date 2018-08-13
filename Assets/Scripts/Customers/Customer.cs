using System;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {

	public Text id;
	public Boolean deliveryReady;

	public String GetID() {
		return id.text;
	}

	public void SetID(String id_) {
		id.text = id_;
		deliveryReady = false;
	}
}
