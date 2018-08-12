using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float speed = 1f;

  Rigidbody2D rb;
  SpriteRenderer spriteRenderer;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
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

  public void Drive() {
    spriteRenderer.enabled = false;
    this.enabled = false;
  }

  public void Walk() {
    spriteRenderer.enabled = true;
    this.enabled = true;
  }
}
