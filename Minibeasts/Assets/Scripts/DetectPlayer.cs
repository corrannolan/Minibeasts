using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectPlayer : MonoBehaviour
{
    public NavMeshAgent Agent;
    public bool AlreadyTriggered = false;
    public float ZSpeed;

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
            if (!AlreadyTriggered)
            {
                Agent.speed = ZSpeed;
                AlreadyTriggered = true;
            }
        }
    }
}