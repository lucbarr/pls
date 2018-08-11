using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float speed = 1f;

  void Start () {
  }

  void Update () {
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Horizontal");
  }
}
