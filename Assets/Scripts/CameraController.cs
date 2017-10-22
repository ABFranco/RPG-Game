using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;

	private static bool cameraExists;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);

		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// gets vector3 of object we are following (default is the player)
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, this.transform.position.z);
		// where we currently are, where we want to be, interpolant to to control midway point between these two positions
		this.transform.position = Vector3.Lerp (this.transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
