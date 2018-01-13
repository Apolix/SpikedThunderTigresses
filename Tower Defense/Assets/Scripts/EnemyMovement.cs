using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float speed = 20f;
    public float health = 1f;
    private Transform target;
    private int waitpointIndex = 0;

    void Start()
    {
        target = Waitpoints.points[0];
        health = Random.Range(1, 4);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaitPoint();
        }
    }

    void GetNextWaitPoint()
    {
        if (waitpointIndex >= Waitpoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waitpointIndex++;
        target = Waitpoints.points[waitpointIndex];
    }
}
