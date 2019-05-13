using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grasshopper : MonoBehaviour
{
    public PlayerMove PM;
    public float GrasshopperJumpForce;
    public bool GrasshopperCanJump;

    void Start()
    {
        PM = GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (GrasshopperCanJump == true)
        {
            if (PM.player.GetButtonDown("Ability"))
            {
                GrasshopperJump();
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GrasshopperCanJump = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GrasshopperCanJump = false;
        }
    }
    void GrasshopperJump()
    {
        PM.RB.AddForce(Vector3.up * GrasshopperJumpForce);
        GrasshopperCanJump = false;
    }
}