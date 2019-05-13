using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busted : MonoBehaviour
{
    public GameObject PS;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Horn")
        {
            GameObject ps = Instantiate(PS, transform.position, new Quaternion());
            gameObject.SetActive(false);
        }
    }
}