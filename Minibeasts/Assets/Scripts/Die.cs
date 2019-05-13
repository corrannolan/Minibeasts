using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float desTime;

    void Start()
    {
        StartCoroutine("SelfDestruct");
    }

    void Update()
    {

    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(desTime);
        Destroy (gameObject);
    }
}