using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public Joystick joystick;
    public Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        float speed = moveSpeed * Time.deltaTime;
        rb.AddForce(moveVector * speed);
    }
}
