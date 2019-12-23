using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_hunter_controls : MonoBehaviour {

	private CharacterController controller;

	private Vector3 moveVector = new Vector3();
	private float verticalVelocity;
	private float gravity = 14.0f;
	private float JumpForce = 10.0f;

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
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					anim.SetTrigger ("isJumping");
					verticalVelocity = JumpForce;
				}
			} else 
			{
				verticalVelocity -= gravity * Time.deltaTime;
			}
			moveVector = new Vector3(0, verticalVelocity, 0);
			controller.Move (moveVector * Time.deltaTime);

		}
	}
}
