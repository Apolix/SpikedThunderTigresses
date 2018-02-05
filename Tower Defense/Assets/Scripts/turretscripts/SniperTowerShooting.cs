using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SniperTowerShooting : MonoBehaviour {

	private GameObject target;
	private GameObject[] enemies;
	public GameObject bulletPrefab;

	public Transform partToRotate;
	public Transform firePosition;

	[Header("Stats")]
	public float range = 30;
	public float attackSpeed = 5f;
	public float turnspeed = 10f; 
	public float damage = 0.3f;
	public float divider = 2;
	float countdownOfShooting = 0.5f;
	public int targeting_type = 0; //0 lowest health, 1 highest health, 2 farthest enemy 
	bool placed = false;
	string targetingtext = "lowest health";
	EnemyMovement enemyscript;

	public string targetingtextget()
	{
		return targetingtext;
	}
	public void targeting_set(Text targetingtext_v)
	{
		targeting_type += 1;
		if (targeting_type > 2) {
			targeting_type = 0;
		}
		if (targeting_type == 0) {
			targetingtext = "lowest health";
			targetingtext_v.text = targetingtext;

		} if(targeting_type == 1) {
			targetingtext = "highest health";
			targetingtext_v.text = targetingtext;
		}
		if (targeting_type == 2) {
			targetingtext = "farthest enemy";
			targetingtext_v.text = targetingtext;
		}
		//targeting text szövege és targeting beállítása
	}

	void UpdateTarget() //megkeresi a potenciális enemyt a beéllitások alapján
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		float health_index_valami_nem_tom = 0;

		if (targeting_type == 1) {
			health_index_valami_nem_tom = 0;
		} if(targeting_type == 0) {
			health_index_valami_nem_tom = Mathf.Infinity;
		}
		float distance = 0;
		float potential_distance = 0;
		GameObject potentialEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			enemyscript = enemy.GetComponent<EnemyMovement> ();
			distance = Vector3.Distance(transform.position, enemy.transform.position);
			if (targeting_type == 1) {
				if (enemyscript.health > health_index_valami_nem_tom) {
					health_index_valami_nem_tom = enemyscript.health;
					potentialEnemy = enemy;
				}
			}

			if (targeting_type == 0) {
				if (enemyscript.health < health_index_valami_nem_tom) {
					health_index_valami_nem_tom = enemyscript.health;
					potentialEnemy = enemy;
				}
			}
			if (targeting_type == 2) {
				if (potential_distance < distance) {
					potential_distance = distance;
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

		float distance = Vector3.Distance(transform.position, enemy_v.transform.position);
		damage = distance / divider;

		if (bullet != null)
		{
			bullet.FindTarget(target, damage);
		}
	}
}
