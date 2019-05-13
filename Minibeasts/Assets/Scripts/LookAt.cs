using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Point;

	void Start ()
    {
	}
	void Update ()
    {
        transform.LookAt(Point.position);
    }
}
