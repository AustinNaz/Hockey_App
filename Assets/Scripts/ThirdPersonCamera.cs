using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [Tooltip("The Object for the Camera to follow")]
    public Transform target;

    [Tooltip("The multiplier for how soft the camera follows the object position")]
    public float positionFactor = 0.1f;

    [Tooltip("The multiplier for how soft the camera rotation is")]
    public float rotationFactor = 0.1f;

    [Tooltip("choose which camera you want 0 = softfollow, 1 = hardfollow, 2 = stopandlook")]
    public int cameraMode = 1;

    /// <summary>
    /// Position of the Camera
    /// </summary>
    private Vector3 pos = new Vector3();

    /// <summary>
    /// Rotation of the Camera
    /// </summary>
    private Quaternion rot = new Quaternion();

    [Tooltip("The Position for the Camera")]
    public Vector3 cameraPos = new Vector3(0, 20, -15);

    [Tooltip("The Rotation for the Camera")]
    public Vector3 cameraRot = new Vector3(30, 0, 0);

	
	// Update is called once per frame
	void Update ()
    {
        if (cameraMode == 0)
        {
            softFollow();
        }
        else if (cameraMode == 1)
        {
            hardFollow();
        }
        else if (cameraMode == 2)
        {
            stopAndLook();
        }

        // Cycle through camera modes with space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraMode = cameraMode + 1;
            if (cameraMode > 2)
            {
                cameraMode = 0;
            }
        }
	}

    private void hardFollow()
    {
        // sets the cameras position and rotation plus extra translation and rotation from public variables
        transform.SetPositionAndRotation(target.position, target.rotation);
        transform.Translate(cameraPos);
        transform.Rotate(cameraRot);
    }

    private void softFollow()
    {
        // sets pos and rot variables to the cameras position and rotation probably a better way too do this
        pos.Set(transform.position.x, transform.position.y, transform.position.z);
        rot.Set(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        // save a few lines recall the hardfollow code
        hardFollow();

        // interpolates the start pos and rot with the targets pos and rot
        Vector3 newPos = Vector3.Lerp(pos, transform.position, positionFactor);
        Quaternion newRot = Quaternion.Slerp(rot, transform.rotation, rotationFactor);

        // sets the interpolated pos and rot
        transform.SetPositionAndRotation(newPos, newRot);
    }

    private void stopAndLook()
    {
        transform.LookAt(target);
    }
}
