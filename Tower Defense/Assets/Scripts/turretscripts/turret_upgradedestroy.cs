using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class turret_upgradedestroy : MonoBehaviour {
	public Canvas upgradedestroy; //canvas
	public Image amit_mozgatsz; //felugró ablak
	public Text destroy_text, upgrade_text;
	public GameObject gamemanager;
	building build_script;
	int turret_cost;
	GameObject turret_v; //a turret amire kattintasz
	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		upgradedestroy.GetComponent<Canvas> ();
		amit_mozgatsz.GetComponent<Image> ();
		upgradedestroy.enabled = false;
		build_script = gamemanager.GetComponent<building> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);//megnézi hol van az egér
			Physics.Raycast(ray, out hit); 

			if (hit.transform.tag=="basic_turret") {
				basic_turret_click ();

			}
			if (hit.transform.tag=="sniper_turret") {
				sniper_turret_click ();

			}
		}
	}

	#region turret_click
	void basic_turret_click()
	{
		upgradedestroy.enabled = true;
		amit_mozgatsz.transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y + 150, Input.mousePosition.z);

		turret_v = hit.transform.gameObject;
		turret_v.GetComponent<shooting> ();
		turret_cost = build_script.turret_1_cost;
		destroy_text.text = "Destroy(" + Mathf.RoundToInt (turret_cost * 0.3f) + " gold)";
	}
	void sniper_turret_click()
	{
		upgradedestroy.enabled = true;
		amit_mozgatsz.transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y + 150, Input.mousePosition.z);

		turret_v = hit.transform.gameObject;
		turret_v.GetComponent<sniper_tower_shooting> ();
		turret_cost = build_script.sniper_tower_cost;
		destroy_text.text = "Destroy(" + Mathf.RoundToInt (turret_cost * 0.3f) + " gold)";
	}
	#endregion



	public void close_window()
	{
		upgradedestroy.enabled = false; //bezárja az ablakot
	}

	public void upgrade_click() //mi történjen upgradénél 								
	{							//turret_v amire kattintasz turret (látja hogy basic vagy sniper turret), turret_cost a turret épitési értéke
		
	}

	public void destroy_click() //destroy
	{
		Destroy (turret_v);
		build_script.gold += Mathf.RoundToInt( turret_cost * 0.3f);
		close_window ();
	}
}
