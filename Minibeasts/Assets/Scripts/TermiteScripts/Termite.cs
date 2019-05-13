using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Termite : MonoBehaviour
{
    Player player;

    PlayerMove pM;
    Mite m;

    public GameObject termPrefab;
    public GameObject activeTerm;
    public GameObject termSpawnPoint;
    public GameObject bouncePrefab;
    public GameObject bounceSpawnPoint;

    bool bombReset = true;

    bool termOut = false;
    bool canPuddle = true;
    public float termSpawnTime;

    public Animator anim;

    AudioSource aS;
    public AudioClip spawnTerm, spawnGoo;

    // Start is called before the first frame update
    void Start()
    {
        pM = GetComponent<PlayerMove>();

        player = pM.player;

        activeTerm = null;

        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeTerm)
        {
            termOut = true;
        }
        else
        {
            if(bombReset == false)
            {
                bombReset = true;
                BombOff();
            }
        }

        if(pM.Alive == true)
        {
            if (pM.player.GetButtonDown("Ability"))
            {
                if (pM.CanJump == true)
                {
                    if (termOut == false)
                    {
                        termOut = true;
                        pM.Speed = 0;
                        pM.CanJump = false;
                        Bomb();
                    }
                }
            }

            if (pM.player.GetButtonDown("Ability2"))
            {
                if (canPuddle == true)
                {
                    canPuddle = false;

                    aS.PlayOneShot(spawnGoo);
                    GameObject gameObject = Instantiate(bouncePrefab, bounceSpawnPoint.transform.position, new Quaternion());

                    StartCoroutine("bounceSpawnCooldown");
                }
            }

        }

    }

    void Bomb()
    {
        pM.Controls = false;

        StartCoroutine(termBomb());
    }

    void BombOff()
    {
        if (pM.Controls == false)
        {
            pM.Controls = true;
            pM.Speed = 10;
            pM.CanJump = true;
        }

        if (termOut == true)
        {
            SpawnCool();
        }
    }

    void SpawnCool()
    {
        StartCoroutine(termSpawnCooldown());
    }

    IEnumerator termBomb()
    {
        anim.SetTrigger("NewSpawn");
        yield return new WaitForSeconds(0.75f);

        aS.PlayOneShot(spawnTerm);

        PlayerMove aPM;
        GameObject newTerm = Instantiate(termPrefab, termSpawnPoint.transform.position, termSpawnPoint.transform.rotation);
        activeTerm = newTerm;

        m = activeTerm.GetComponent<Mite>();
        aPM = activeTerm.GetComponent<PlayerMove>();
        aPM.PlayerID = pM.PlayerID;
        aPM.Cam = pM.Cam;
        aPM.cameraTransformSorta = pM.cameraTransformSorta;

        m.release = true;
        m.Mission();

        bombReset = false;
    }

    IEnumerator termSpawnCooldown()
    {
        yield return new WaitForSeconds(termSpawnTime);
        termOut = false;
    }

    IEnumerator bounceSpawnCooldown()
    {
        yield return new WaitForSeconds(5);
        canPuddle = true;
    }
}
