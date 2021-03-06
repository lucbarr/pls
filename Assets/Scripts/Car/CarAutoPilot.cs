﻿using UnityEngine;

public class CarAutoPilot : MonoBehaviour {
  public float duration;
  public float accelDuration = 0.5f;

  public float reactionDistance = 0.5f;
  public float stopDistance = 0.1f;
  public LayerMask stopMask;

  public Transform[] frontPoints;

  BezierSpline spline;

  float accel;
  float progress;

  void Start() {
    spline = GameObject.FindWithTag("CarQueue").GetComponent<BezierSpline>();
  }

  void UpdateAccel() {
    float minDist = 2*reactionDistance + stopDistance;

    RaycastHit2D hit;

    foreach (var point in frontPoints) {
      hit = Physics2D.Raycast(point.position, point.up, minDist, stopMask);
      if (hit.collider != null) {
        minDist = Mathf.Min(minDist, hit.distance);
      }
    }

    minDist -= stopDistance;

    accel = minDist < 0f ?
      0f :
      Mathf.Clamp01(accel + (minDist > reactionDistance ? 1 : -1) * Time.deltaTime / accelDuration);
  }

  void Update () {
    UpdateAccel();

    progress += accel * Time.deltaTime / duration;
    if (progress > 1f) {
      progress = 1f;
    }

    Vector3 position = spline.GetPoint(progress);
    transform.localPosition = position;

    Vector3 target = position + spline.GetDirection(progress);
    Vector3 diff = target - transform.position;
    diff.Normalize();
    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
  }
}
