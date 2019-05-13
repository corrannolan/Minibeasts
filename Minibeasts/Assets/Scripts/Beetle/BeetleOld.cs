using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleOld : MonoBehaviour
{
    public PlayerMove PM;
    public GameObject Hook;
    public GameObject Hierarchy;
    public GameObject Hover;
    public bool CanCarry = false;
    public bool Carrying = false;
    public bool CanFly;
    GameObject Buddy;
    PlayerMove Pal;

    void Start()
    {
        PM = GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (PM.CanJump == true)
        {
            CanFly = true;
        }
        if (CanFly == true)
        {
            if (PM.player.GetButtonDown("Ability"))
            {
                transform.localPosition = Hover.transform.position;
                PM.RB.useGravity = false;
                if (CanCarry == true)
                {
                    Pal.RB.detectCollisions = false;
                    Pal.RB.useGravity = false;
                    Buddy.transform.parent = transform;
                    Buddy.transform.localPosition = Hook.transform.localPosition;
                    Pal.enabled = false;
                    Carrying = true;
                }
            }
        }
        if (PM.player.GetButtonUp("Ability"))
        {
            PM.RB.useGravity = true;
            CanFly = false;
            if (Carrying == true)
            {
                Pal.enabled = false;
                Pal.RB.detectCollisions = true;
                Pal.RB.useGravity = true;
                Buddy.transform.parent = transform;
                Buddy.transform.position = Hook.transform.position;
                Buddy.transform.parent = null;
                Carrying = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanCarry = true;
            Buddy = other.gameObject;
            Pal = other.GetComponent<PlayerMove>();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanCarry = false;
            Carrying = false;
            Buddy = null;
            Pal = null;
        }
    }
}