using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class building : MonoBehaviour {

    public GameObject red_turret_of_death, sniper_tower;
	public Text gold_txt; 
	int cost = 0;
	bool build_mode = false;

	public int gold = 20, turret_1_cost = 20, sniper_tower_cost = 40;

	void Update ()
    {
		gold_txt.text = gold.ToString (); //ki legyen irva mennyi goldod van
	}


	public void turrer1_click()
	{
		if (build_mode == false && gold > turret_1_cost - 1) {
			build_mode = true;
			cost = turret_1_cost;
			build (red_turret_of_death); //click esemény a turretgombhoz a shopban azért van külön metódusba mert igy később egyszerű lesz 
		}
	}

	public void sniper_tower_click()
	{
		if (build_mode == false && gold > sniper_tower_cost - 1) {
			build_mode = true;
			cost = sniper_tower_cost;
			build (sniper_tower); //click esemény a turretgombhoz a shopban azért van külön metódusba mert igy később egyszerű lesz 
		}
	}

	public void building_turret()
	{
		build_mode = false;  // build mode ne lehessen egymásba stackelni
		gold = gold - cost;
		cost = 0;
	}
	public void canceling_building()
	{
		cost = 0;
		build_mode = false;
	}
	public void build(GameObject turret_v)
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //megnézi hol van az egér
		RaycastHit hit; //ez egy raycast

		if (Physics.Raycast (ray, out hit)) {

			Vector3 rounded_position = new Vector3 (Mathf.Round (hit.transform.position.x), hit.transform.position.y + 2f, Mathf.Round (hit.transform.position.z)); //kerekíti a pozícióját a turretnek hogy a kockákra rakja le
			Instantiate (turret_v, rounded_position, Quaternion.identity); // lespawnol egy turrettet
		}
	}
}
