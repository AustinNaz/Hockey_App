using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Tooltip("How fast the player moves")]
    public float moveSpeed = 20;

    public float stickSpeed = 10;

    [Tooltip("The joystick Gameobject to control the player")]
    public Joystick pJoystick;

    [Tooltip("The Rigidbod component attached to the player")]
    public Rigidbody prb;

    [Tooltip("The joystick Gameobject to control the stick")]
    public Joystick sJoystick;

    [Tooltip("The Rigidbod component attached to the stick")]
    public Rigidbody srb;

    [Tooltip("The Stick Gameobject the player uses")]
    public Transform stick;

    [Tooltip("The Puck Gameobject")]
    public Transform puck;

    // The Sticks Postiion and Rotation
    private Vector3 stickPos = new Vector3(2.5f, 3, 1);
    private Quaternion stickRot;

    // The Pucks Position and Rotation in relation to the stick
    private Vector3 puckPos = new Vector3(-2.5f, -3.15f, 0.65f);
    private Quaternion puckRot;

    // Reset the player position
    private Vector3 resetPos = new Vector3(-2, 0, -20);
    private Quaternion resetRot = new Quaternion(0, 0, 0, 0);

    // Use this for initialization
    void Start ()
    {
        prb = GetComponent<Rigidbody>();
        srb = stick.GetComponent<Rigidbody>();

        // the Original stick and puck rotation
        //stickRot = stick.rotation;
        puckRot = puck.rotation;
	}
	
	// Update is called once per frame should move this too Fixedupdate but it looks janky in there
	void Update ()
    {
        Vector3 moveVector = (transform.right * pJoystick.Horizontal + transform.forward * pJoystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        float speed = moveSpeed * Time.deltaTime;
        prb.AddForce(moveVector * speed);

        Vector3 stickMoveVector = (stick.transform.right * sJoystick.Vertical + stick.transform.forward * sJoystick.Horizontal).normalized;
        stick.transform.Rotate(stickMoveVector * stickSpeed * Time.deltaTime);
        float speedTest = stickSpeed * Time.deltaTime;
        srb.AddForce(stickMoveVector * speedTest);
        
        AttachStick();

        // If the bool in Stickblade is true attach the puck
        if (StickBlade.inContact)
        {
            AttachPuck();
        }

        // When R is pressed reset the players position 
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetPosition();
        }
    }

    // Resets the players position when called
    private void resetPosition()
    {
        transform.SetPositionAndRotation(resetPos, resetRot);
    }

    public void AttachPuck()
    {
        // Sets the puck too the sticks position but keeps the pucks rotation
        puck.SetPositionAndRotation(stick.position, puckRot);
        // Translates the puck into position from stick base
        puck.position = puck.position + puckPos;
    }

    private void AttachStick()
    {
        // Sets the stick too the players position but keeps the sticks rotation
        //stick.SetPositionAndRotation(transform.position, stickRot);
        stick.position = transform.position;
        // Translates the stick into position from player base
        stick.position = stick.position + stickPos;
    }
}
