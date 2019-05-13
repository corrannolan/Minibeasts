using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermiteDestruction : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
    }
    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.layer == 16)
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}