using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBlade : MonoBehaviour {

    public float radius = 2;
    public LayerMask layerMask;
    public GameObject puck;

    public Vector3 puckPos = new Vector3(0, 0, 0);
    //private Quaternion puckRot = new Quaternion();
    private Vector3 lastPosition = new Vector3();
    private bool inContact = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Physics.CheckSphere(transform.position, radius, layerMask))
        {
            print("YAHA");
            inContact = true;
            //puck.transform.SetPositionAndRotation(transform.position, puckRot);
        }

        if (inContact)
        {
            puck.transform.position += transform.position - lastPosition;
        }

        lastPosition = transform.position;
    }
}

