using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAutoPilot : MonoBehaviour {
  public float duration;

  public float stopDistance = 0.1f;
  public LayerMask stopMask;

  public Transform frontPoint;

  BezierSpline spline;
  public Animator anim;

  float progress;

  public void StartAnimator(){
    anim = GetComponent<Animator>();
  }

  void Start() {
    spline = GameObject.FindWithTag("CustomerQueue").GetComponent<BezierSpline>();
  }

  bool CanMove() {
    RaycastHit2D hit;
    hit = Physics2D.Raycast(frontPoint.position, frontPoint.up, stopDistance, stopMask);
    Debug.DrawLine(frontPoint.position, frontPoint.position + frontPoint.up * stopDistance);
    return hit.collider == null;
  }

  void Update () {
    if (CanMove()) {
      progress += Time.deltaTime / duration;
      if (progress > 1f) {
        progress = 1f;
        anim.SetBool("isIdle", true);
      } else {
        anim.SetBool("isIdle", false);
      }
    } else {
      anim.SetBool("isIdle", true);
    }

    Vector3 position = spline.GetPoint(progress);
    transform.localPosition = position;

    Vector3 target = position + spline.GetDirection(progress);
    Vector3 diff = target - transform.position;
    diff.Normalize();
    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    /*
    const float eps = 0.1f;
    float modx = Mathf.Abs(delta.x);
    float mody = Mathf.Abs(delta.y);
    bool tilted = ( modx > eps && mody > eps );
    bool idle   = ( modx <= eps && mody <= eps );
    anim.SetBool("isTilted", tilted);
    anim.SetBool("isIdle", idle);
    */
  }
}
