using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour {

    public GameObject red_turret_of_death;
	bool build_mode = false;

	void Update ()
    {
		if (Input.GetKey(KeyCode.Mouse0)) { //build mode = false ne lehessen egyszerre több tornyot lerakni
			build_mode = false;
		}

		if (build_mode == false) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) { //kelllet egy gomb tesztre ez holnap már itt se lesz
				build_mode = true;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //megnézi hol van az egér
				RaycastHit hit; //ez egy raycast

				if (Physics.Raycast (ray, out hit)) {

					Vector3 rounded_position = new Vector3 (Mathf.Round (hit.transform.position.x), hit.transform.position.y, Mathf.Round (hit.transform.position.z)); //kerekíti a pozícióját a turretnek hogy a kockákra rakja le
					Instantiate (red_turret_of_death, rounded_position, Quaternion.identity); // lespawnol egy turrettet
                }
			}
		}
	}
}
