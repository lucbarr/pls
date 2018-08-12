using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour {
  ScoreController scorectrl;

  public float speed     = 1f;//velocidade de aceleração/freio
  public float turnSpeed = 1f;//velocidade de giro
  public float nota;

  float movVertical;
  float movHorizontal;

  private Rigidbody2D rb;
  private BoxCollider2D colider;
  public Text notex;
  bool batido = false;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
    scorectrl = GameObject.FindWithTag("Score Controller");
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

  void OnCollisionEnter2D(Collision2D coll)
  {
      if(batido == false && coll.gameObject.tag != "Player" )
      {
        nota -= 1f;
        batido = true;
        scorectrl.Bateu();
      }
  }
  void OnCollisionExit2D(Collision2D coll)
  {
    batido = false;
  }
  public bool Batida()
  {
    if(batido == true)
    {
      return true;
    }
    else
      return false;
  }
}
