using UnityEngine;

public class SplineWalker : MonoBehaviour {

	public BezierSpline spline;

	public float duration;

	public bool lookForward;

	public SplineWalkerMode mode;

	private float progress;
	private bool goingForward = true;

	private void Update () {
		if (goingForward) {
			progress += Time.deltaTime / duration;
			if (progress > 1f) {
				if (mode == SplineWalkerMode.Once) {
					progress = 1f;
				}
				else if (mode == SplineWalkerMode.Loop) {
					progress -= 1f;
				}
				else {
					progress = 2f - progress;
					goingForward = false;
				}
			}
		}
		else {
			progress -= Time.deltaTime / duration;
			if (progress < 0f) {
				progress = -progress;
				goingForward = true;
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		if (lookForward) {
			//transform.LookAt(position + spline.GetDirection(progress));

      // XXX: making it work on 2D
      Vector3 target = position + spline.GetDirection(progress);
      Vector3 diff = target - transform.position;
      diff.Normalize();
      float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		}
	}
}
