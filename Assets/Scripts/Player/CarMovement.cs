using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {
  public float speed     = 1f;//velocidade de aceleração/freio
  public float turnSpeed = 1f;//velocidade de giro

  float movVertical;
  float movHorizontal;

  private Rigidbody2D rb;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update () {
    movHorizontal = Input.GetAxis("Horizontal");
    movVertical = Input.GetAxis("Vertical");

    Move ();
    Turn();
  }

  private void Move () {
    Vector2 movement = transform.up * movVertical * speed;
    rb.AddForce(movement);
  }

  private void Turn() {
    float moveProp = Mathf.Clamp01(rb.velocity.magnitude);
    float turn = moveProp * turnSpeed * movHorizontal * Mathf.Sign(movVertical) * Time.deltaTime;
    rb.MoveRotation (rb.rotation - turn);
  }
}
