using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

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
	bool placed = false;

	void UpdateTarget()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		float minDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(transform.position, enemy.transform.position);


			if (distance < minDistance)
			{
				minDistance = distance;
				nearestEnemy = enemy;
			}
		}
		if (nearestEnemy != null && minDistance <= range)
		{
			target = nearestEnemy;
		}
		else { target = null; }
	}
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Mouse1) && placed == false)
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
