using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private CharacterController controller;

	private Vector3 moveVector;
	private float verticalVelocity;
	private float gravity = 15.0f;
	private float JumpForce = 9.0f;

	static Animator anim;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManager.Instance.Paused) {
			if (controller.isGrounded) {
				verticalVelocity = -gravity * Time.deltaTime;
				if (Input.GetKeyDown (KeyCode.Space)) {
					anim.SetTrigger ("isJumping");
					verticalVelocity = JumpForce;
				}
			} else {
				verticalVelocity -= gravity * Time.deltaTime;
			}
			Vector3 moveVector = new Vector3 (0, verticalVelocity, 0);
			controller.Move (moveVector * Time.deltaTime);

		}
	}
}
