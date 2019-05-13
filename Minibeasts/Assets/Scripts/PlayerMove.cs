using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMove : MonoBehaviour
{
    public Player player;
    public int PlayerID;

    public Health H;

    public Rigidbody RB;

    public GameObject Cam;

    float heading;

    public Transform cameraTransformSorta;
    private float moveH, moveV;
    public float Speed = 10;
    public float JumpForce;

    public bool CanMove = true;
    public bool Controls = true;
    public bool CanJump;
    bool isWalking = false;

    public float KnockbackDuration;
    Vector3 KnockbackDirection;
    public bool Hurt = false;
    public bool Alive = true;

    public Animator[] anims;

    public AudioSource wS;
    public AudioClip footSteps, jumpUp;

    void Start()
    {
        player = ReInput.players.GetPlayer(PlayerID);

        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Controls == true)
        {
            moveH = player.GetAxis("MoveX");
            moveV = player.GetAxis("MoveY");

            RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            if (CanJump == true)
            {
                if (moveH != 0 || moveV != 0)
                {
                    if (isWalking == false)
                    {
                        wS.clip = footSteps;
                        wS.Play();
                        wS.loop = true;
                        isWalking = true;
                    }

                    foreach (Animator anim in anims)
                    {
                        anim.SetBool("Walking", true);
                    }
                }
                else
                {
                    RB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

                    foreach (Animator anim in anims)
                    {
                        anim.SetBool("Walking", false);
                    }

                    if(isWalking == true)
                    {
                        wS.loop = false;
                        wS.Stop();
                        wS.clip = null;
                        isWalking = false;
                    }
                }

                if(Alive == true)
                {
                    if (player.GetButtonDown("Jump"))
                    {
                        Jump();
                    }
                }
            }
        }
        else
        {
            RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            foreach (Animator anim in anims)
            {
                anim.SetBool("Walking", false);
            }

            if (isWalking == true)
            {
                wS.loop = false;
                wS.Stop();
                wS.clip = null;
                isWalking = false;
            }
        }

        if (player.GetButtonDown("Restart"))
        {
            GameManager gM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gM.Restart();
        }
    }

    public void FixedUpdate()
    {
        Vector3 Movement = ((cameraTransformSorta.forward * moveV) * Speed) + ((cameraTransformSorta.right * moveH) * Speed);
        RB.velocity = new Vector3(Movement.x, RB.velocity.y, Movement.z);
        if (Movement.x != 0 && Movement.z != 0)
        {
            heading = Mathf.Atan2(Movement.x, Movement.z) * Mathf.Rad2Deg;
        }

        RB.rotation = Quaternion.Euler(0, heading, 0);
    }

    void OnCollisionEnter(Collision other)
    {

        if (Hurt == false)
        {
            if (other.gameObject.tag == "Hazard" || other.gameObject.tag == "Projectile")
            {
                H.Life -= 2;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            foreach (Animator anim in anims)
            {
                anim.SetBool("Jumping", false);
            }

            CanJump = true;
        }

        if (Hurt == false)
        {
            if (other.gameObject.tag == "ZombieBite")
            {
                Damaged();
            }

            if (other.gameObject.tag == "BigFuckingRock")
            {
                H.Life -= 2;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            foreach (Animator anim in anims)
            {
                anim.SetBool("Jumping", false);
            }

            CanJump = true;
        }
    }

    public void Jump()
    {
        foreach (Animator anim in anims)
        {
            anim.SetBool("Jumping", true);
            wS.PlayOneShot(jumpUp);
        }

        RB.velocity = Vector3.zero;
        RB.AddForce(transform.up * JumpForce);
        CanJump = false;
    }

    void Damaged()
    {
        H.Life -= 1;
        Hurt = true;
        Controls = false;
        StartCoroutine("GetUp");
    }

    IEnumerator GetUp()
    {
        yield return new WaitForSeconds(KnockbackDuration);
        Controls = true;
        yield return new WaitForSeconds(2);
        Hurt = false;
    }
}