using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    public PlayerMove PM;

    public GameObject Horn;
    public GameObject WingShield;

    public float Recharge;
    public float ChargeForce;

    public bool ReadyToCharge = true;
    public bool Charging = false;
    public bool Cooling = false;
    public bool Shielding = false;

    Animator anim;

    AudioSource aS;
    public AudioClip charge, wingOp, wingCl;

    void Start()
    {
        PM = GetComponent<PlayerMove>();

        anim = GetComponent<Animator>();

        aS = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Charging == true)
        {
            Horn.SetActive(true);
        }
        else if (Charging == false)
        {
            Horn.SetActive(false);

            if (Cooling == true)
            {
                PM.Speed = 5;
            }
        }
    }

    void Update()
    {
        if(Cooling == true)
        {
            anim.SetBool("Walking", false);
        }

        if(PM.Alive == true)
        {
            if (ReadyToCharge == true)
            {
                if (PM.CanJump == true)
                {
                    if (PM.player.GetButtonDown("Ability"))
                    {
                        anim.SetBool("Charging", true);
                        PM.Controls = false;
                        aS.PlayOneShot(charge);

                        Charging = true;
                        PM.Speed = 25;
                        StartCoroutine("Relax");
                    }
                }
            }

            if (PM.player.GetButtonDown("Ability2"))
            {
                if (Shielding == false)
                    Shield();
            }
        }

        if (PM.player.GetButtonUp("Ability2"))
        {
            aS.PlayOneShot(wingCl);
            anim.SetBool("Shielding", false);
            PM.CanJump = true;
            WingShield.SetActive(false);
            ReadyToCharge = true;
            Shielding = false;
        }
    }

    void Shield()
    {
        aS.PlayOneShot(wingOp);
        Shielding = true;
        ReadyToCharge = false;
        PM.CanJump = false;
        WingShield.SetActive(true);
        anim.SetBool("Shielding", true);
    }

    IEnumerator Relax()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Charging", false);
        yield return new WaitForSeconds(0.2f);
        PM.Controls = true;
        Cooling = true;
        ReadyToCharge = false;
        Charging = false;

        yield return new WaitForSeconds(Recharge);
        Cooling = false;
        PM.Speed = 10;
        ReadyToCharge = true;
    }
}