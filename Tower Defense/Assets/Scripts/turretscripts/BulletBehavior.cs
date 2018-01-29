using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private GameObject target;
	private GameObject gamemanager; 
	private building gold;
	private WaveSpawner spawner;
    private Transform targetTransform;
	public int gold_killenként = 10;
    public float bulletSpeed = 50f, damage;

    public void FindTarget(GameObject vTarget, float vDamage)
    {
        //Változók beállítása másik scriptől
        target = vTarget;
        damage = vDamage;
    }
	void Start()
	{
		gamemanager = GameObject.FindGameObjectWithTag ("manager");
		gold = gamemanager.GetComponent<building> ();
		spawner = gamemanager.GetComponent<WaveSpawner> ();
        targetTransform = target.transform;
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
        Vector3 direction = targetTransform.position - transform.position;
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
			gold.gold += gold_killenként; // 10 goldot kapp minden kill után
            Instantiate(enemy.Coin, new Vector3(target.transform.position.x, 3f, target.transform.position.z), enemy.Coin.transform.rotation);
            spawner.enemykill();
            Destroy(target);
        }

        Destroy(gameObject);
    }
}
