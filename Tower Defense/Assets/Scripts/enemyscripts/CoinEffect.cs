using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffect : MonoBehaviour {

    public float turnSpeed = 200f;
    public float risingSpeed = 5f;
    public float lifeSpan = 3.5f;

	void Update ()
    {
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * turnSpeed));
        transform.Translate(new Vector3(0, 0, Time.deltaTime * -risingSpeed));
        lifeSpan -= Time.deltaTime;
    }
}
