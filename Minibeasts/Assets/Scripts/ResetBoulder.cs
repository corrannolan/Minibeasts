using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBoulder : MonoBehaviour
{
    public GameObject Boulder;
    public GameObject Spawner;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Boulder.gameObject)
        {
            Boulder.transform.position = Spawner.transform.position;
        }
    }
}