using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicShooting : MonoBehaviour {

	private GameObject target;
	private GameObject[] enemies;
	public GameObject bulletPrefab;

	public Transform partToRotate;
	public Transform firePosition;

	[Header("Stats")]
	public float range = 15f;
	public float attackSpeed = 0.2f;
	public float turnspeed = 10f; 
	public float damage = 1f;
	float countdownOfShooting = 0.5f;
	bool highest_health_target = false;
	bool placed = false;
	EnemyMovement enemyscript;

	void UpdateTarget()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		float health_index_valami_nem_tom;

		if (highest_health_target == true) {
			health_index_valami_nem_tom = 0;
		} else {
			health_index_valami_nem_tom = Mathf.Infinity;
		}
		float distance = 0;
		GameObject potentialEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			enemyscript = enemy.GetComponent<EnemyMovement> ();
			distance = Vector3.Distance(transform.position, enemy.transform.position);
			if (highest_health_target == true) {
				if (enemyscript.health > health_index_valami_nem_tom) {
					health_index_valami_nem_tom = enemyscript.health;
					potentialEnemy = enemy;
				}
			}

			if (highest_health_target == false) {
				if (enemyscript.health < health_index_valami_nem_tom) {
					health_index_valami_nem_tom = enemyscript.health;
					potentialEnemy = enemy;
				}
			}


		}
		if (potentialEnemy != null && distance <= range)
		{
			target = potentialEnemy;
		}
		else { target = null; }
	}

	public void targeting_set(Text targetingtext_v)
	{
		highest_health_target = !highest_health_target;
		if (highest_health_target == false) {
			targetingtext_v.text = "lowest health";

		} else {
			targetingtext_v.text = "highest health";
		}
		print (highest_health_target);
	}

	void Update()
	{

        if (transform.position.y <= 2f && placed == false)
		{
			InvokeRepeating("UpdateTarget", 0f, 0.5f);
			placed = true;
		}
		if (target == null)
			return;

		Vector3 direction = target.transform.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (countdownOfShooting <= 0f)
		{
			Shoot(target);
			countdownOfShooting = attackSpeed;
		}
		countdownOfShooting -= Time.deltaTime;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	void Shoot(GameObject enemy_v)
	{
		GameObject whereToGo = (GameObject)Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
		BulletBehavior bullet = whereToGo.GetComponent<BulletBehavior>();

		if (bullet != null)
		{
			bullet.FindTarget(target, damage);
		}
	}
}
