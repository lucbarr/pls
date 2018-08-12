using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	GameObject player;
	GameObject car;
	bool colisao;
	public float score = 45f;
	public Text notex;
	public Text sefudeu;
	bool scorectrl = true;
	
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		colisao = false;
	}
	
	
	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			car = player.GetComponent<CarInteraction>().GetCar();
		}
		if(car != null)
		{
			colisao = car.GetComponent<CarMovement>().Batida();
		}
		else
			colisao = false;
		notex.text = "Nota: " + (score/10f).ToString();	
		if(score<= 0f)
		{
			score = 0f;
			sefudeu.text = "SE FUDEU";
		}
	}

	public void Bateu()
	{
		if(colisao == true && score > 0)
		{
			score -= 1f;
		}
	}
}
