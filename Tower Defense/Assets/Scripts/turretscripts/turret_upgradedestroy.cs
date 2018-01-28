using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class turret_upgradedestroy : MonoBehaviour {
	public Canvas upgradedestroy; //canvas
	public Image amit_mozgatsz; //felugró ablak
	GameObject turret_v; //a turret amire kattintasz
	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		upgradedestroy.GetComponent<Canvas> ();
		amit_mozgatsz.GetComponent<Image> ();
		upgradedestroy.enabled = false;

		turret_v.GetComponent<shooting> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			turret_click ();
		}
	}
	void turret_click()
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
		upgradedestroy.enabled = false; //bezárja az ablakot
	}
	public void upgrade_click() //mi történjen upgradénél
	{
		
	}
	public void destroy_click() //destroy
	{
		
	}
}
