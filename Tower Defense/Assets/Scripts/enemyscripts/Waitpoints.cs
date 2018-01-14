using UnityEngine;
using System.Collections;

public class Waitpoints : MonoBehaviour {

    public static Transform[] points;

        // csak létrehoz egy Transform tömböt a Waitpointoknak
        void Awake()
    { 
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
