using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour {

	Ray ray, ray_tagging;
	RaycastHit hit, hit_tagging;
	Vector3 rounded_position;
	public Material texture;


	void Update ()
    {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);//megnézi hol van az egér
		Physics.Raycast(ray, out hit); 

		rounded_position = new Vector3 (Mathf.Round (hit.transform.position.x), 1, Mathf.Round (hit.transform.position.z));
		transform.position = rounded_position; //kerekíti a pozícióját a turretnek hogy a kockákra rakja le

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Destroy (gameObject); //cancel placing (so enlish much wow)
		}

		Physics.Raycast (transform.position, Vector3.down, out hit_tagging, 10); //még egy raycast ami a tagét nézi meg az turret alatti objektumnak

		if (hit_tagging.transform.gameObject.tag == "ground") //groundnak neveztem el a füvet
        {
			GetComponent<Renderer> ().material.color = Color.green; //itt kéne zöldnek lennie a turretnek (kísértetiesen nem működik de nincs error)
			if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
				GetComponent<Renderer> ().material = texture; //simma texture lesz
				Destroy (this); //elpusztítja ezt a scriptet
            }
		}
        else
        {
			GetComponent<Renderer> ().material.color = Color.red;//itt kéne pirosnak lennie a turretnek (kísértetiesen nem működik de nincs error)
		}
	}
}
