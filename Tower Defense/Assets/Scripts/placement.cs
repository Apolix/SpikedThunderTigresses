using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour {
	Ray ray, ray_tagging;
	RaycastHit hit, hit_tagging;
	Vector3 kerekített_pozíció;
	public GameObject turret;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);

		kerekített_pozíció = new Vector3 (Mathf.Round (hit.transform.position.x), 1, Mathf.Round (hit.transform.position.z));
		transform.position = kerekített_pozíció;


		Physics.Raycast (transform.position, Vector3.down, out hit_tagging, 10);

		if (hit_tagging.transform.gameObject.tag == "ground") {
			GetComponent<Renderer> ().material.color = Color.green;
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				GetComponent<Renderer> ().material.color = Color.black;
				gameObject.AddComponent<shooting> ();
				Destroy (this);
			}
		} else {
			GetComponent<Renderer> ().material.color = Color.red;
		}
	}
}
