using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour {
	public GameObject red_turret_of_death;
	bool build_mode = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0)) {
			build_mode = false;
		}

		if (build_mode == false) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
					Vector3 kerekített_pozíció = new Vector3 (Mathf.Round (hit.transform.position.x), hit.transform.position.y, Mathf.Round (hit.transform.position.z));
					Instantiate (red_turret_of_death, kerekített_pozíció, Quaternion.identity);
				}
			}
		}
	}
}
