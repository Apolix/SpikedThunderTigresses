using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class turret_upgradedestroy : MonoBehaviour {
<<<<<<< HEAD:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs
	public Canvas upgradedestroy; //canvas
	public Image amit_mozgatsz; //felugró ablak
<<<<<<< HEAD:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs
	public Text destroy_text, upgrade_text;
	public GameObject gamemanager;
	building build_script;
	int turret_cost;
=======
	public Canvas upgradeDestroy; //canvas
	public Image StatImage; //felugró ablak
>>>>>>> 08890a17d7be9e6da5e9b85941cbdefbb5b85a39:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs
=======
>>>>>>> parent of 6dc6a9e... destroy+ változók:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs
	GameObject turret_v; //a turret amire kattintasz
	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
<<<<<<< HEAD:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs
		upgradedestroy.GetComponent<Canvas> ();
		amit_mozgatsz.GetComponent<Image> ();
		upgradedestroy.enabled = false;
<<<<<<< HEAD:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs
		build_script = gamemanager.GetComponent<building> ();
=======
		upgradeDestroy.GetComponent<Canvas> ();
		StatImage.GetComponent<Image> ();
		upgradeDestroy.enabled = false;

		turret_v.GetComponent<shooting> ();
>>>>>>> 08890a17d7be9e6da5e9b85941cbdefbb5b85a39:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs
=======

		turret_v.GetComponent<shooting> ();
>>>>>>> parent of 6dc6a9e... destroy+ változók:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			turret_click ();
		}
	}
<<<<<<< HEAD:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs

	#region turret_click
	void basic_turret_click()
	{
<<<<<<< HEAD:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs
		upgradedestroy.enabled = true;
		amit_mozgatsz.transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y + 150, Input.mousePosition.z);

		turret_v = hit.transform.gameObject;
		turret_v.GetComponent<shooting> ();
		turret_cost = build_script.turret_1_cost;
		destroy_text.text = "Destroy(" + Mathf.RoundToInt (turret_cost * 0.3f) + " gold)";
=======
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);//megnézi hol van az egér
		Physics.Raycast(ray, out hit); 
		if (hit.transform.tag=="turret") {
            Transform turret = hit.transform;
			upgradeDestroy.enabled = true;          
            StatImage.transform.position = new Vector3(Mathf.Round(Input.mousePosition.x), Input.mousePosition.y + 2f, Mathf.Round(Input.mousePosition.z));

			turret_v = hit.transform.gameObject;
			turret_v.GetComponent<shooting> ();
		} else {
			close_window ();
		}
>>>>>>> 08890a17d7be9e6da5e9b85941cbdefbb5b85a39:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs
	}
	void sniper_turret_click()
=======
	void turret_click()
>>>>>>> parent of 6dc6a9e... destroy+ változók:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);//megnézi hol van az egér
		Physics.Raycast(ray, out hit); 
		if (hit.transform.tag=="turret") {
			upgradedestroy.enabled = true;
			amit_mozgatsz.transform.position = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y + 150, Input.mousePosition.z);

			turret_v = hit.transform.gameObject;
			turret_v.GetComponent<shooting> ();
		} else {
			close_window ();
		}
	}
	public void close_window()
	{
		upgradeDestroy.enabled = false; //bezárja az ablakot
	}
<<<<<<< HEAD:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs
<<<<<<< HEAD:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs

	public void upgrade_click() //mi történjen upgradénél 								
	{							//turret_v amire kattintasz turret (látja hogy basic vagy sniper turret), turret_cost a turret épitési értéke
=======
	public void upgrade_click() //mi történjen upgradénél
	{
>>>>>>> parent of 6dc6a9e... destroy+ változók:Tower Defense/Assets/Scripts/turretscripts/turret_upgradedestroy.cs
		
=======
	public void upgrade_click() //mi történjen upgradénél
	{
        print("update");
>>>>>>> 08890a17d7be9e6da5e9b85941cbdefbb5b85a39:Tower Defense/Assets/Scripts/menuscripts/turret_upgradedestroy.cs
	}
	public void destroy_click() //destroy
	{
		
	}
}
