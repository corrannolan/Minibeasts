using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public Material Red;
    public GameObject Baby;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Door")
        {
            Destroy(other.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            gameObject.tag = "Item";
            Baby.layer = 0;
        }
    }
}