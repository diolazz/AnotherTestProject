using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float smothing = 5f;

    void Start()
    {
        offset = transform.position - target.position;
    }

	void FixedUpdate () {
	    if (target != null)
	    {
	        FollowTarget();
	    }
	}

    private void FollowTarget()
    {
        Vector3 cameraNewPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, cameraNewPosition, smothing * Time.deltaTime);
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
