using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

	GameObject[] enemies;
	public GameObject damage;
	public float range = 15, attack_speed = 100;
	float ticker = 0;
	bool placed = false;
	
	void Update ()
    {
		if (Input.GetKey(KeyCode.Mouse0)) {
			placed = true;
		}
		if (placed == true) {

			enemies = GameObject.FindGameObjectsWithTag ("enemy");
            float minDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

			foreach (GameObject enemy in enemies)
            {
				float distance = Vector3.Distance (transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy;
                }
			}
            if (nearestEnemy != null && minDistance <= range && ticker == attack_speed)
            {
                shoot(nearestEnemy);
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

	void shoot(GameObject enemy_v)
	{
		Destroy (enemy_v);
		ticker = 0;
	}
}
