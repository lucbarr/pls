using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoviment : MonoBehaviour {

	public float normSpeed = 1f;//velocidade de aceleração/freio
	public float turnSpeed = 1f;//velocidade de giro
	float movVertical;
	float movHorizontal;
	private Rigidbody2D carrb;
	// Use this for initialization
	void Start () 
	{
		carrb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movHorizontal = Input.GetAxis("Horizontal");
		movVertical = Input.GetAxis("Vertical");
		Move ();
		Turn();
		SideDrag();
		
		//Turn ();
		//Vector2 mov = new Vector2(movHorizontal,movvertical); 
    	//carrb.AddForce(mov*speed);
	}
	 private void Move ()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector2 movement = transform.up * movVertical * normSpeed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        carrb.AddForce(transform.up * movVertical * normSpeed);
    }
	private void Turn()
    {
		float moveProp = Mathf.Clamp01(carrb.velocity.magnitude);
		float turn = moveProp*turnSpeed*movHorizontal * Mathf.Sign(movVertical) *Time.deltaTime;
        // Apply this rotation to the rigidbody's rotation.
        carrb.MoveRotation (carrb.rotation + turn);
    }
	private void SideDrag()
	{
		Vector2 velocity = transform.InverseTransformVector(carrb.velocity);
		carrb.AddForce(transform.right * -velocity.x * 20);

	}
}
