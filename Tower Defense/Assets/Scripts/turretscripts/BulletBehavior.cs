﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    private GameObject target;
	private GameObject gamemanager; 
	private WaveSpawner spawner;
    private Vector3 targetTransform;
    private building gold;
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
		spawner = gamemanager.GetComponent<WaveSpawner> ();
        gold = gamemanager.GetComponent<building>();
        targetTransform = target.transform.position;
    }
	void FixedUpdate ()
    {
        //Óvatosság
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Bullet mozgása
        Vector3 direction = targetTransform - transform.position;
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
            gold.gold += enemy.goldPerKill; // 10 goldot kapp minden kill után
            Instantiate(enemy.Coin, new Vector3(target.transform.position.x, 3f, target.transform.position.z), enemy.Coin.transform.rotation);
            spawner.enemykill();         
        }

        Destroy(gameObject);
    }
}
