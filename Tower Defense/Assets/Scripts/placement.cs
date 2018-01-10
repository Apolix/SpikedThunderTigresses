using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour {

	Ray ray, ray_tagging;
	RaycastHit hit, hit_tagging;
	Vector3 rounded_position;

	public GameObject turret;

	void Update ()
    {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);

		rounded_position = new Vector3 (Mathf.Round (hit.transform.position.x), 1, Mathf.Round (hit.transform.position.z));
		transform.position = rounded_position;

		Physics.Raycast (transform.position, Vector3.down, out hit_tagging, 10);

		if (hit_tagging.transform.gameObject.tag == "ground")
        {
			GetComponent<Renderer> ().material.color = Color.green;
			if (Input.GetKeyDown(KeyCode.Mouse0))
            {
				GetComponent<Renderer> ().material.color = Color.black;
				gameObject.AddComponent<shooting> ();
				Destroy (this);
            }
		}
        else
        {
			GetComponent<Renderer> ().material.color = Color.red;
		}
	}
}
