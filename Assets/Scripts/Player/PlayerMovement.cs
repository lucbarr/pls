using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float speed = 1f;

  Rigidbody2D rb;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update () {
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    if (Mathf.Abs(inputX) > 0.2f || Mathf.Abs(inputY) > 0.2f) {
      transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(-inputX, inputY) * Mathf.Rad2Deg);
      rb.velocity = transform.up * speed;
    } else {
      rb.velocity = Vector2.zero;
    }
  }
}
