using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour {
	public float lookSpeed = 40;
	//public int ballSpeed = 20; this was being weird.
	public GameObject ballPrefab;
	public Transform ballSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float speed = lookSpeed * Time.deltaTime;

		transform.Rotate(0f, Input.GetAxis("Horizontal") * speed, 0f, Space.World);
		transform.Rotate(-Input.GetAxis("Vertical") * speed,  0f, 0f, Space.Self);


		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}
	}

	void Fire(){
		//Create the ball from the ball prefab
		var ball = (GameObject)Instantiate (
			           ballPrefab,
			           ballSpawn.position,
			           ballSpawn.rotation);

		//Add velocity to the ball
		ball.GetComponent<Rigidbody>().velocity = ball.transform.up * 15; //Change this number if you want to increase ball speed

		//Destroy the ball after 5 seconds
		Destroy(ball, 5.0f);
	
	}
}
