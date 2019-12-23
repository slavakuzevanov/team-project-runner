using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModer : MonoBehaviour {
    private float coinCounter = 0.0f;
    public Text coinsText;
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f;
    private bool isDead = false;
    private float startTime;
	public Button [] Buttons;
	public GameObject [] Buttons1;
	public GameObject Pause;
	private float JumpForce = 10.0f;
	static Animator anim;
    // Use this for initialization
    void Start() {
		if (Global.control != 3) {
			for (int i = 0; i < 3; i++) {
				Buttons1 [i].SetActive (false);
			}
		}
		anim = GetComponent<Animator> ();	
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
	{
		if (GameManager.Instance.Paused == false)
		{
			if (isDead) {
				return;
			}
			if (Time.time - startTime < animationDuration) {
				controller.Move (Vector3.forward * speed * Time.deltaTime);
				return;
			}
			moveVector = Vector3.zero;
			if (controller.isGrounded) {
				verticalVelocity = -0.5f;
			} else {
				verticalVelocity -= gravity * Time.deltaTime;
				if (controller.transform.position.y < -2) {
					Death ();
				}
			}
			moveVector.x = Input.GetAxisRaw ("Horizontal") * speed;


			if (Input.GetMouseButton (0)) {
				if (Global.control == 1)
				{
				if (Input.mousePosition.x > Screen.width / 2)
					moveVector.x = speed;
				else
					moveVector.x = -speed;
			}
				if (Global.control == 2)
				{
					if (Input.mousePosition.x > 2 * Screen.width / 3)
						moveVector.x = speed;
					else
						if (Input.mousePosition.x <  Screen.width / 3)
						moveVector.x = -speed;
							}
			}

			if (Input.GetMouseButton (0)) {
									if (Global.control == 2)
									{
				if (controller.isGrounded) {
					verticalVelocity = -0.5f;
						if ((Input.mousePosition.x > Screen.width / 3) && (Input.mousePosition.x < 2 * Screen.width / 3)) {
						anim.SetTrigger ("isJumping");
						verticalVelocity = JumpForce;
					}
				} else {
					verticalVelocity -= gravity * Time.deltaTime;
				}
			}
				if (Global.control == 1)
				{
					if (controller.isGrounded) {
						verticalVelocity = -0.5f;
						if (Input.mousePosition.y > Screen.height / 3) {
							anim.SetTrigger ("isJumping");
							verticalVelocity = JumpForce;
						}
					} else {
						verticalVelocity -= gravity * Time.deltaTime;
					}
				}
			if (Global.control == 3)
			{
				for (int i = 0; i < 3; i++)
				{
					Buttons1 [i].SetActive (true);
				}
				Buttons [0].onClick.AddListener (Left);
				Buttons [1].onClick.AddListener (Right);
				Buttons [2].onClick.AddListener (Jump);
			}
								}
			moveVector.y = verticalVelocity;
			moveVector.z = speed;
			controller.Move (moveVector * Time.deltaTime);
		}
		}
	
    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
		if (hit.gameObject.tag == "Enemy" )
		{
			Death();
		}
        if (hit.gameObject.tag == "Coin")
        {
            Destroy(hit.gameObject);
            coinCounter++;
            PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins")+1.0f);
            coinsText.text = ((int)coinCounter).ToString();
        }
    }

    private void Death()
    {
		Pause.SetActive (false);
        isDead = true;
        coinsText.text = "";
        GetComponent<Score>().OnDeath();
		speed = 0.0f;
    }
	void Right()
	{
		if (!GameManager.Instance.Paused) {
			if (isDead) {
				return;
			}
			if (Time.time - startTime < animationDuration) {
				controller.Move (Vector3.forward * speed * Time.deltaTime);
				return;
			}
			moveVector = Vector3.zero;
			if (controller.isGrounded) {
				verticalVelocity = -0.5f;
			} else {
				verticalVelocity -= gravity * Time.deltaTime;
				if (controller.transform.position.y < -2) {
					Death ();
				}
			}
			moveVector.x = Input.GetAxisRaw ("Horizontal") * speed;

			moveVector.x = speed;
		}
	}
	void Left()
	{
		moveVector.x = -speed;
	}
	void Jump()
	{
		if (controller.isGrounded)
		{
			verticalVelocity = -0.5f;
			anim.SetTrigger ("isJumping");
			verticalVelocity = JumpForce;
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

	}
}
