using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class building : MonoBehaviour {

    public GameObject red_turret_of_death;
	public Text gold_txt;
	int cost = 0;
	bool build_mode = false;

	public int gold = 20, ticker = 0;

	void Update ()
    {
		gold_txt.text = gold.ToString (); //ki legyen irva mennyi goldod van

		if (Input.GetKeyDown(KeyCode.Mouse1) ) {
			build_mode = false;  // build mode ne lehessen egymásba stackelni
			gold = gold - cost;
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			cost = 0;
			build_mode = false;
		}
		print (build_mode);
	}
	void FixedUpdate()
	{
		ticker += 1;
		if (ticker == 30) { 
			ticker = 0;
			gold += 1; // ticker a goldhoz
		}
	}
	public void turrer1_click()
	{
		if (build_mode == false && gold > 19) {
			build_mode = true;
			cost = 20;
			build (red_turret_of_death); //click esemény a turretgombhoz a shopban azért van külön metódusba mert igy később egyszerű lesz 
		}
	}
	public void build(GameObject turret_v)
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //megnézi hol van az egér
		RaycastHit hit; //ez egy raycast

		if (Physics.Raycast (ray, out hit)) {

			Vector3 rounded_position = new Vector3 (Mathf.Round (hit.transform.position.x), hit.transform.position.y, Mathf.Round (hit.transform.position.z)); //kerekíti a pozícióját a turretnek hogy a kockákra rakja le
			Instantiate (turret_v, rounded_position, Quaternion.identity); // lespawnol egy turrettet
		}
	}
}
