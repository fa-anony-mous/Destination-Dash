using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
	public bool follow = true;

	// Target to follow.
	public Transform target;
	public float height = 20.0f;
	public float smoothDampTime = 0.5f;

	// The point in at which the camera will be set in full view.
	[SerializeField] private Transform allMapViewPosition = null;

	private Vector3 smoothDampVel;

	void LateUpdate()
	{
		if (!target || !follow)
			return;
		SmoothDampToTarget();
	}

	public void SmoothDampToTarget()
	{
		Vector3 cameraOffset = new Vector3(0, 10, -25);
		if(target == null)
			GotoAllMapView();
		// var targetPosition = target.position + Vector3.up * height;
		// var targetPosition = target.position + target.TransformPoint(cameraOffset);
		// transform.position = targetPosition;
		
		// // transform.position = Vector3.SmoothDamp(
		// // 	transform.position,
		// // 	targetPosition,
		// // 	ref smoothDampVel,
		// // 	smoothDampTime
		// // );

		// transform.SetParent(target);

		transform.position = target.position + target.TransformDirection(cameraOffset);

            // Make the camera look at the car
        transform.LookAt(target);
	}

	public void GotoAllMapView()
	{
		if (allMapViewPosition == null)
			return;

		transform.position = allMapViewPosition.position;
		// transform.SetParent(null); // Unparent the camera.
		transform.rotation = allMapViewPosition.rotation;
	}
}
