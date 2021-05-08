using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 7f;
    public float maxSpeed = 20f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public bool midAirJump = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (speed <= maxSpeed)
        {
            speed += 0.0025f;
        }

        controller.Move(move * speed * Time.deltaTime);
        if(x == 0 && z == 0)
        {
            speed = 7f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);    
                midAirJump = true;
            }
            else if (midAirJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);    
                midAirJump = false;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
