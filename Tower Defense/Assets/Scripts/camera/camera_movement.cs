using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour {
	public CharacterController player;
	float moveEH, moveJB, zoom;
	public float speed, scrollspeed;
	Vector3 movement;
	// Use this for initialization
	void Start () {
		player.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveJB = Input.GetAxis ("Horizontal") * speed;
		moveEH = Input.GetAxis ("Vertical") * speed;
		zoom = Input.GetAxis ("Mouse ScrollWheel") * scrollspeed;

		if (transform.position.y > 66 && zoom > 0) {
			zoom = 0;
		}
		if (transform.position.y < 20 && zoom < 0) {
			zoom = 0;
		}

		Vector3 movement = new Vector3 (-moveEH, zoom, moveJB);
		player.Move (movement * Time.deltaTime);
	}
}
