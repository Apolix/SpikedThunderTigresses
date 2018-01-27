using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class turret_upgradedestroy : MonoBehaviour {
	public Canvas upgradeDestroy; //canvas
	public Image StatImage; //felugró ablak
	GameObject turret_v; //a turret amire kattintasz
	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		upgradeDestroy.GetComponent<Canvas> ();
		StatImage.GetComponent<Image> ();
		upgradeDestroy.enabled = false;

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
            Transform turret = hit.transform;
			upgradeDestroy.enabled = true;          
            StatImage.transform.position = new Vector3(Mathf.Round(Input.mousePosition.x), Input.mousePosition.y + 2f, Mathf.Round(Input.mousePosition.z));

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
	public void upgrade_click() //mi történjen upgradénél
	{
        print("update");
	}
	public void destroy_click() //destroy
	{
		
	}
}
