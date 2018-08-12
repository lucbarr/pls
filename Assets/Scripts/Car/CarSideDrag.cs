using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSideDrag : MonoBehaviour {
  public float sideDrag  = 20f;

  Rigidbody2D rb;

  void Start () {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update () {
    SideDrag();
  }

  private void SideDrag() {
    Vector3 velocity = transform.InverseTransformVector(rb.velocity);
    rb.AddForce(transform.right * -velocity.x * sideDrag);
  }
}
