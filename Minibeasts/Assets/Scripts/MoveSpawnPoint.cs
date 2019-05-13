using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawnPoint : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject NewSpawnLocation;
    private bool AlreadyHit = false;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (!AlreadyHit)
        {
            if (other.gameObject.tag == "Player")
            {
                SpawnPoint.transform.position = NewSpawnLocation.transform.position;
                AlreadyHit = true;
            }
        }
    }
}