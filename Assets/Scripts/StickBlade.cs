using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBlade : MonoBehaviour {

    public float radius = 2;
    public LayerMask layerMask;
    public GameObject puck;

    //public Vector3 puckPos = new Vector3(0, 0, 0);
    //private Quaternion puckRot = new Quaternion();
    //private Vector3 lastPosition = new Vector3();
    public static bool inContact = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Physics.CheckSphere(transform.position, radius, layerMask))
        {
            //print("YAHA");
            inContact = true;
        }
    }
}

