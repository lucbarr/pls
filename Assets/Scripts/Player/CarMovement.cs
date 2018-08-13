using UnityEngine;

public class CarMovement : MonoBehaviour {
  public float speed     = 1f;
  public float turnSpeed = 1f;

  float movVertical;
  float movHorizontal;

  Rigidbody2D rb;
  ScoreController scoreController;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
    scoreController = GameObject.FindWithTag("Score Controller").GetComponent<ScoreController>();
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
    float sign = Mathf.Sign(transform.InverseTransformVector(rb.velocity).y);
    float turn = moveProp * turnSpeed * movHorizontal * sign * Time.deltaTime;
    rb.MoveRotation (rb.rotation - turn);
  }

  void OnCollisionEnter2D(Collision2D coll) {
    if (enabled && !coll.gameObject.CompareTag("Player")) {
      scoreController.CarHit();
    }
  }
}
