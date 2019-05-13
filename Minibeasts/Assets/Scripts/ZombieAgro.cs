using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAgro : MonoBehaviour
{
    public Patrol pT;

    public GameObject radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pT.Meat = other.gameObject;
            radius.SetActive(false);
            print("ladies and gentlemen, we got him");
            print(pT.Meat);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == pT.Meat)
        {
            radius.SetActive(true);
            print("we dont gotem");
        }
    }
}
