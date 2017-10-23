using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;
	private float currentSpeed;
	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private Vector2 lastMove;

	float horiz;
	float vert;

	private static bool playerExists;

	public string startPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D>();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		horiz = 0f;
		vert = 0f;
		playerMoving = false;

		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
			horiz = Input.GetAxisRaw ("Horizontal");
			//transform.Translate (new Vector3 (horiz * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentSpeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (horiz, 0f);
		}
		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
			vert = Input.GetAxisRaw ("Vertical");
			//transform.Translate (new Vector3 (0f, vert * moveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0f, vert);
		}

		// reset velocity back to 0
		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
		}

		if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
			// diagonal movement is occurring
			currentSpeed = moveSpeed * 0.707f;

		} else {
			currentSpeed = moveSpeed;
		}


		anim.SetFloat ("MoveX", horiz);
		anim.SetFloat ("MoveY", vert);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
		anim.SetBool ("PlayerMoving", playerMoving);

	}

	public void editLastMove (Vector2 newLastMove) {
		lastMove = newLastMove;
	}
}
