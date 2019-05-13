using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSpawnersOn : MonoBehaviour
{
    public GameObject Spawners;
    public bool Triggered = false;
    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!Triggered)
            {
                Spawners.SetActive(true);
                Triggered = true;
            }
        }
    }
}