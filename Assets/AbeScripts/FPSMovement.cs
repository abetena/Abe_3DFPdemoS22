using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public float jumpForce = 3f;

    //Gravity and falling variables
    Vector3 velocity;
    bool isGrounded;

    public float gravity = -9.5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        //CheckSphere cast a spehere FROM the groundCheck, AT the ground Disntance, TO the objects in the ground Mask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //reset velocity is is in the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Check inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Create vector motion
        Vector3 move = transform.right * x + transform.forward * z;

        //move controller, multiplied by speed and by the time regardless of framerate
        controller.Move(move * speed * Time.deltaTime);


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
