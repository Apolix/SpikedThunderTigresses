using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IngameMenuScript : MonoBehaviour {

	public Button build, turret_1;
	public Canvas standard_menu, build_menu;
	public GameObject red_turret_of_death;
	public Image Build_background;

	// Use this for initialization
	void Start () {
		build.GetComponent<Button> ();
		standard_menu.GetComponent<Canvas> ();
		build_menu.GetComponent<Canvas> ();
		build_menu.enabled = false;
		Build_background.GetComponent<Image> ();
	}
	public void turret_1_click()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //megnézi hol van az egér
		RaycastHit hit; //ez egy raycast

		if (Physics.Raycast (ray, out hit)) {

			Vector3 rounded_position = new Vector3 (Mathf.Round (hit.transform.position.x), hit.transform.position.y, Mathf.Round (hit.transform.position.z)); //kerekíti a pozícióját a turretnek hogy a kockákra rakja le
			Instantiate (red_turret_of_death, rounded_position, Quaternion.identity); // lespawnol egy turrettet
		}
		build_menu.enabled = false;
		build.enabled = true;
		Build_background.enabled = true;
	}
	public void Build_click()
	{
		build_menu.enabled = true;
		build.enabled = false;
		Build_background.enabled = false;

	}

}
