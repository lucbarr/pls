using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : MonoBehaviour {

	CircleCollider2D coll;
	public GameObject car;
	// Use this for initialization
	void Start () 
	{
		coll = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Car_Door")
		{
			if(Input.GetKeyUp("space"))
			{
				this.gameObject.SetActive(false);
				car.GetComponent<CarMoviment>().enabled = true;
				this.transform.parent = car.transform;
			}
		}
	}
}
