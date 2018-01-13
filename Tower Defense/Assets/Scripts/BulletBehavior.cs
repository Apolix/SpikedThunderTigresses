using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private GameObject target;

    public float bulletSpeed = 50f, damage;

    public void FindTarget(GameObject vTarget, float vDamage)
    {
        target = vTarget;
        damage = vDamage;
    }
	
	void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.transform.position - transform.position;
        float currentDistance = bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= currentDistance)
        {
            TargetDamageOnHit();
        }
        else
        {
            transform.Translate(direction.normalized * currentDistance, Space.World);
        }
	}

    void TargetDamageOnHit()
    {
        EnemyMovement enemy = target.GetComponent<EnemyMovement>();

        enemy.health -= damage;
        if (enemy.health <= 0)
        {
            Destroy(target);
        }

        Destroy(gameObject);
    }
}
