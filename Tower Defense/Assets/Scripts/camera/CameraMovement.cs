using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public CharacterController player;
	float moveEH, moveJB, zoom;
	public float speed, scrollspeed;
	public GameObject gamemanager;
	TurretUpgradeAndDestroy popup;
	public float zoom_min = 20, zoom_max = 66, EH_lock_min,EH_lock_max, JB_lock_min, JB_lock_max;
	Vector3 movement;
	// Use this for initialization
	void Start () {
		player.GetComponent<CharacterController> ();
		popup = gamemanager.GetComponent<TurretUpgradeAndDestroy> ();
	}

	
	// Update is called once per frame
	void Update () {
		moveJB = Input.GetAxis ("Horizontal") * speed;
		moveEH = Input.GetAxis ("Vertical") * speed;
		zoom = Input.GetAxis ("Mouse ScrollWheel") * -scrollspeed;

		if (transform.position.y > zoom_max && zoom > 0 || transform.position.y < zoom_min && zoom < 0) {
			zoom = 0;
		}
		if (transform.position.x > EH_lock_max && -moveEH > 0 || transform.position.x < EH_lock_min && -moveEH < 0) {
			moveEH = 0;
		}
		if (transform.position.z > JB_lock_max && moveJB > 0 || transform.position.z < JB_lock_min && moveJB < 0) {
			moveJB = 0;
		}

		if (moveEH != 0 || moveJB != 0) {
			popup.close_window ();
		}

		Vector3 movement = new Vector3 (-moveEH, zoom, moveJB);
		player.Move (movement * Time.deltaTime);
	}
}
