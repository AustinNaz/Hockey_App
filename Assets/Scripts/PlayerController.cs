using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Tooltip("How fast the player moves")]
    public float moveSpeed;

    [Tooltip("The joystick Gameobject to control the player")]
    public Joystick joystick;

    [Tooltip("The Rigidbod component attached to the player")]
    public Rigidbody rb;

    [Tooltip("The Stick Gameobject the player uses")]
    public Transform stick;

    // The Sticks Postiion and Rotation
    private Vector3 stickPos = new Vector3(2.5f, 3, 1);
    private Quaternion stickRot;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        stickRot = stick.rotation;
	}
	
	// Update is called once per frame should move this too Fixedupdate but it looks janky in there
	void Update ()
    {
        Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        float speed = moveSpeed * Time.deltaTime;
        rb.AddForce(moveVector * speed);
        AttachStick();
    }

    private void AttachStick()
    {
        // Sets the stick too the players position but keeps the sticks rotation
        stick.SetPositionAndRotation(transform.position, stickRot);
        // Translates the stick into position from player base
        stick.position = stick.position + stickPos;
    }
}
