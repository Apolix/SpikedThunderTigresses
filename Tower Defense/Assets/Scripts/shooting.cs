using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    GameObject target;
	GameObject[] enemies;
    public Transform PartToRotate;
    public float range = 15, attack_speed = 2, turnspeed = 10f;
    float countdownOfShooting = 0.5f;
	bool placed = false;

    void Start()
    {

    }
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && placed == false)
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
            placed = true;
        }
        if (target == null)
            return;

        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (countdownOfShooting <= 0f)
        {
            Shoot(target);
            countdownOfShooting = attack_speed;
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
		Destroy (enemy_v);
	}
}
