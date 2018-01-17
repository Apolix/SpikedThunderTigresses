using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private GameObject target;

    public float bulletSpeed = 50f, damage;

    public void FindTarget(GameObject vTarget, float vDamage)
    {
        //Változók beállítása másik scriptől
        target = vTarget;
        damage = vDamage;
		print (vDamage);
    }
	
	void Update ()
    {
        //Óvatosság
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Bullet mozgása
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
        //Ellenség életének csökentése a sebzés alapján
        EnemyMovement enemy = target.GetComponent<EnemyMovement>();

        enemy.health -= damage;
        if (enemy.health <= 0)
        {
            Destroy(target);
        }

        Destroy(gameObject);
    }
}
