using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Patrol Pat;

    public Rigidbody RB;

    public GameObject AttackBox;

    bool isMoving;
    public float ZSpeed;

    public bool ReadyToAttack = true;

    Animator anim;

    AudioSource aS;
    public AudioClip footsteps, zBite;

    void Start()
    {
        RB = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Pat.Agent.velocity.magnitude > 0)
        {
            if(isMoving == false)
            {
                aS.clip = footsteps;
                aS.Play();
                aS.loop = true;
                isMoving = true;
            }

            anim.SetBool("Running", true);
        }
        else
        {
            if(isMoving == true)
            {
                aS.loop = false;
                aS.Stop();
                aS.clip = null;
                isMoving = false;
            }
        }

        if(ReadyToAttack == false)
        {
            if (isMoving == true)
            {
                aS.loop = false;
                aS.Stop();
                aS.clip = null;
                isMoving = false;
            }

            //RB.velocity = Vector3.zero;
        }
        /*else
        {
            RB.velocity = RB.velocity;
        }*/
    }

    void OnCollisionEnter(Collision other)
    {
        if (ReadyToAttack == true)
        {
            if (other.gameObject.tag == "Player")
            {
                StartCoroutine("Attack");
                ReadyToAttack = false;
            }
        }
    }

    IEnumerator Attack()
    {
        Pat.Agent.isStopped = true;
        //Pat.Agent.enabled = false;
        //RB.constraints = RigidbodyConstraints.FreezeAll;
        anim.SetBool("Running", false);
        anim.SetTrigger("Bite");
        yield return new WaitForSeconds(0.75f);

        aS.PlayOneShot(zBite);
        AttackBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        AttackBox.SetActive(false);

        //RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        Pat.Agent.isStopped = false;
        Pat.GotoNextPoint();
        Pat.Agent.speed = ZSpeed;
        anim.SetBool("Running", true);
        yield return new WaitForSeconds(1);

        ReadyToAttack = true;
    }
}