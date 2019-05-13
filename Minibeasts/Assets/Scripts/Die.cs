using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("SelfDestruct");
    }
    void Update()
    {
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(15);
        Destroy (gameObject);
    }
}