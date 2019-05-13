using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Ant : MonoBehaviour
{
    PlayerMove PM;
    Player player;

    Rigidbody rB;

    Animator anim;

    public bool AntCanGrab = false;
    public bool isGrabbing = false;

    public GameObject pickup;
    public GameObject cO;
    Rigidbody cRB;
    BoxCollider cC;
    SphereCollider sC;
    bool sphere;
    float newPos;
    public float ThrowForce;

    bool spitting = false;
    public float sprayTime;
    public GameObject fireBox;
    public float coolTime;

    AudioSource aS;
    public AudioClip grab, fireBr;

    void Start()
    {
        PM = GetComponent<PlayerMove>();
        player = PM.player;

        rB = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(PM.Alive == true)
        {
            if (AntCanGrab == true)
            {
                if (PM.player.GetButtonDown("Ability"))
                {
                    if (isGrabbing == false)
                    {
                        aS.PlayOneShot(grab);
                    }

                    anim.SetBool("Carrying", true);
                    StopCoroutine("ChromeBook");
                    cRB.useGravity = false;
                    cRB.isKinematic = true;
                    cRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    if (sphere == true)
                    {
                        sC.enabled = false;
                    }
                    else
                    {
                        cC.enabled = false;
                    }

                    cO.transform.parent = pickup.transform;
                    if(sphere == true)
                    {
                        float newPos = sC.radius / 2;
                    }
                    else
                    {
                        float newPos = cC.size.x / 2;
                    }

                    print(newPos);
                    cO.transform.localPosition = new Vector3(0, 0, newPos);
                    cO.transform.rotation = PM.RB.rotation;
                    cO.transform.Rotate(0, 90, 0);

                    isGrabbing = true;
                }
            }
        }

        if (isGrabbing == true)
        {
            PM.CanJump = false;

            if (PM.player.GetButtonUp("Ability"))
            {
                anim.SetBool("Carrying", false);

                if (cO.layer == 23)
                {
                    cRB.isKinematic = false;
                    cRB.useGravity = true;

                    cRB.AddForce(transform.forward * ThrowForce);
                    cRB.AddForce(transform.up * ThrowForce);

                    isGrabbing = false;
                    cO.transform.parent = null;
                    AntCanGrab = true;
                    PM.CanJump = true;

                    StartCoroutine("Roll");
                }
                else
                {
                    cRB.isKinematic = false;
                    cRB.useGravity = true;

                    cRB.AddForce(transform.forward * ThrowForce);
                    cRB.AddForce(transform.up * ThrowForce);

                    isGrabbing = false;
                    cO.transform.parent = null;
                    AntCanGrab = true;
                    PM.CanJump = true;

                    StartCoroutine("ChromeBook");
                }
            }
        }

        if (PM.player.GetButtonDown("Ability2"))
        {
            if(PM.Alive == true)
            {
                print("got gotted");
                FlameSpit();
            }
        }

        if(PM.Alive == false)
        {
            if(isGrabbing == true)
            {
                anim.SetBool("Carrying", false);

                if (cO.layer == 23)
                {
                    cRB.isKinematic = false;
                    cRB.useGravity = true;

                    cRB.AddForce(transform.forward * ThrowForce);
                    cRB.AddForce(transform.up * ThrowForce);

                    isGrabbing = false;
                    cO.transform.parent = null;
                    AntCanGrab = true;
                    PM.CanJump = true;

                    StartCoroutine("Roll");
                }
                else
                {
                    cRB.isKinematic = false;
                    cRB.useGravity = true;

                    cRB.AddForce(transform.forward * ThrowForce);
                    cRB.AddForce(transform.up * ThrowForce);

                    isGrabbing = false;
                    cO.transform.parent = null;
                    AntCanGrab = true;
                    PM.CanJump = true;

                    StartCoroutine("ChromeBook");
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            if (isGrabbing == false)
            {
                if(cO != other.gameObject)
                {
                    AntCanGrab = true;
                    cO = other.gameObject;
                    cRB = other.GetComponent<Rigidbody>();
                    if(other.gameObject.layer == 23)
                    {
                        sC = other.GetComponent<SphereCollider>();
                        sphere = true;
                    }
                    else
                    {
                        cC = other.GetComponent<BoxCollider>();
                        sphere = false;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            if(isGrabbing == false)
            {
                AntCanGrab = false;
                cO = null;
            }
        }
    }

    IEnumerator ChromeBook()
    {
        yield return new WaitForSeconds(0.25f);
        cC.enabled = true;
        yield return new WaitForSeconds(0.75f);
        cRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    void FlameSpit()
    {
        if (spitting == false)
        {
            spitting = true;
            StartCoroutine(spit());
        }
    }

    IEnumerator spit()
    {
        aS.clip = fireBr;
        aS.Play();
        aS.loop = true;
        fireBox.SetActive(true);
        PM.Speed = 5;
        anim.speed = 0.5f;
        yield return new WaitForSeconds(sprayTime);

        aS.loop = false;
        aS.Stop();
        aS.clip = null;
        fireBox.SetActive(false);
        anim.speed = 1;
        PM.Speed = 10;

        yield return new WaitForSeconds(coolTime);
        spitting = false;
    }

    IEnumerator Roll()
    {
        yield return new WaitForSeconds(0.5f);
        sC.enabled = true;
        cRB.constraints = RigidbodyConstraints.None;
    }
}