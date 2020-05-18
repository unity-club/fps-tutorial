using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public CharacterController controller;
	public GameObject bullet;
	public float sensitivity = 100;
	public float gravity = -9.81f;
	public float groundRadius = 1;
	public float jumpSpeed = 10;
	public Transform groundCheck;
	public LayerMask groundMask;
	private Vector3 velocity;
	private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Rigidbody rigidbody = GameObject.Instantiate(bullet).GetComponent<Rigidbody>();
			rigidbody.transform.position = transform.position + transform.forward;
			rigidbody.velocity = transform.forward * 50f;
		}

		isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
		if (isGrounded)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				velocity.y = jumpSpeed;
			} else
			{
				velocity.y = 0;
			}
		}
		else velocity.y += gravity * Time.deltaTime; 

		// 1 when we are moving forward, -1 when moving backward
		float vertical = sensitivity * Input.GetAxis("Vertical") * Time.deltaTime; 
		float horizontal = sensitivity * Input.GetAxis("Horizontal") * Time.deltaTime;

		Vector3 forward = transform.forward * vertical;
		Vector3 strafe = transform.right * horizontal;

		controller.Move(forward + strafe + velocity * Time.deltaTime);
    }
}
