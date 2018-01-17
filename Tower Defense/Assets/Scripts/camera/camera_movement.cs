using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour {
	public CharacterController player;
	float moveEH, moveJB, zoom;
	public float speed;
	Vector3 movement;
	// Use this for initialization
	void Start () {
		player.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveJB = Input.GetAxis ("Horizontal") * speed;
		moveEH = Input.GetAxis ("Vertical") * speed;
		

		Vector3 movement = new Vector3 (-moveEH, zoom, moveJB);
		player.Move (movement * Time.deltaTime);
	}
}
