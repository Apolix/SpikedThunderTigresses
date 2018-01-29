using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public GameObject Coin;
    public float speed = 20f;
    public float health = 1f;
    public int goldPerKill = 10;

    private GameObject gamemanager;
    private WaveSpawner spawner;
    private Transform target;
    private int waitpointIndex = 0;

    void Start()
    {
        //A Ellenség életének és index számának beállítása
        target = Waitpoints.points[0];    
		gamemanager = GameObject.FindGameObjectWithTag ("manager");
		spawner = gamemanager.GetComponent<WaveSpawner> ();
    }

    void Update()
    {
        //Ellenségek mozgása
        Vector3 dir = target.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) <= (speed / 100))
        {
            GetNextWaitPoint();
        }
    }

    void GetNextWaitPoint()
    {
        //Új waitpontot kap ami felé mozog ha eléri az utolsót megsemisül
        if (waitpointIndex >= Waitpoints.points.Length - 1)
        {         
            Destroy(gameObject);
			spawner.enemykill ();
            return;
        }
        waitpointIndex++;
        target = Waitpoints.points[waitpointIndex];
    }
}
