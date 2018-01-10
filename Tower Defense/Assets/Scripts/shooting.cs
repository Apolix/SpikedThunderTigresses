using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {
	GameObject[] ellenségek;
	public GameObject damage;
	public float range = 15, attack_speed = 100;
	float ticker = 0;
	// Use this for initialization
	void Start () {
		print ("itt vagyok ragyogok mint a fekete szurok");
	}
	
	// Update is called once per frame
	void Update () {
		ellenségek = GameObject.FindGameObjectsWithTag ("enemy");
		foreach (GameObject enemy in ellenségek) {
			float távolság = Vector3.Distance (transform.position, enemy.transform.position);
			if (távolság < range && ticker == attack_speed) {
				shoot (enemy);
			}
		}
	}
	void FixedUpdate()
	{
		if (ticker < attack_speed) {
			ticker += 1;
		}
		print (ticker);

	}
	void shoot(GameObject enemy_v)
	{
		Destroy (enemy_v);
		ticker = 0;
	}
}
