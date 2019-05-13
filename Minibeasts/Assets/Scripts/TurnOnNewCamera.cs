using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnNewCamera : MonoBehaviour
{
    public GameObject NewCam;
    public bool One = false;
    public bool Two = false;
    public bool Three = false;
    public bool Yeet = false;
    public GameObject Termite;
    public GameObject Beetle;
    public GameObject Ant;

    void Start()
    {
    }
    void FixedUpdate()
    {
        if (One == true && Two == true && Three == true)
        {
            Yeet = true;
        }
        else if (One == false || Two == false || Three == false)
        {
            Yeet = false;
        }
        if (Yeet == true)
        {
            NewCam.SetActive(true);
        }
        else if (Yeet == false)
        {
            NewCam.SetActive(false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Termite)
        {
            One = true;
        }
        if (other.gameObject == Beetle)
        {
            Two = true;
        }
        if (other.gameObject == Ant)
        {
            Three = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Termite)
        {
            One = false;
        }
        if (other.gameObject == Beetle)
        {
            Two = false;
        }
        if (other.gameObject == Ant)
        {
            Three = false;
        }
    }
}