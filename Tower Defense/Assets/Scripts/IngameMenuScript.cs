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
	public void Build_click()
	{
		build_menu.enabled = true;
		build.enabled = false;
		Build_background.enabled = false;

	}

}
