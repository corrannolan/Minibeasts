using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public NavMeshAgent Agent;

    public GameObject Meat;

    public Transform[] Points;
    public bool Go = false;
    private int destPoint = 0;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Meat = other.gameObject;
            Go = true;
            print("laydees n gintlmen, wi gotum");
            print(Meat);
        }
    }

    public void GotoNextPoint()
    {
        if(Points.Length == 0)
        {
            return;
        }
        
        Agent.SetDestination(Meat.transform.position);
        destPoint = (destPoint + 1) % Points.Length;
    }

    void Update()
    {
        if (Go == true)
        {
            if (Agent.remainingDistance < 5)
            {
                GotoNextPoint();
            }
        }
    }
}
