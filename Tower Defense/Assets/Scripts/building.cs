using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour {

    public GameObject red_turret_of_death;
	bool build_mode = false;

	void Update ()
    {
		if (Input.GetKey(KeyCode.Mouse0)) {
			build_mode = false;
		}

		if (build_mode == false) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				build_mode = true;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {

					Vector3 rounded_position = new Vector3 (Mathf.Round (hit.transform.position.x), hit.transform.position.y + 1, Mathf.Round (hit.transform.position.z));
					Instantiate (red_turret_of_death, rounded_position, Quaternion.identity);
                }
			}
		}
	}
}
