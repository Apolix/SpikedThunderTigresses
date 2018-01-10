using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

	GameObject[] enemies;
	public GameObject damage;
	public float range = 15, attack_speed = 100;
	float ticker = 0;

	void Start ()
    {
		print ("itt vagyok ragyogok mint a fekete szurok");
	}
	
	void Update ()
    {
		enemies= GameObject.FindGameObjectsWithTag ("enemy");
		foreach (GameObject enemy in enemies)
        {
			float distance = Vector3.Distance (transform.position, enemy.transform.position);
			if (distance < range && ticker == attack_speed)
            {
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
