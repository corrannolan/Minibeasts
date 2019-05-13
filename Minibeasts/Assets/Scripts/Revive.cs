using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public Health H;
    PlayerMove PM;

    int playersNear = 0;
    public int Countdown;
    public GameObject Green;

    public AudioSource aS;
    public AudioClip revived;

    void Start()
    {
        
    }

    void Update()
    {
        if (Countdown <= 0.1)
        {
            if(H.PM.Alive == false)
            {
                aS.PlayOneShot(revived);
                H.Life = 2;
                H.PM.Alive = true;
                H.PM.Speed = 10;
                H.HelpMe.SetActive(false);
                StartCoroutine("GetLost");
            } 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(H.PM.Alive == false)
        {
            if (other.gameObject.tag == "Player")
            {
                PM = other.GetComponent<PlayerMove>();

                if (PM.Alive == true)
                {
                    playersNear++;
                    StartCoroutine("Heal");
                    Green.SetActive(true);
                }
            }
        }

        if(other.gameObject.tag == "Death")
        {
            if (H.PM.Alive == false)
            {
                aS.PlayOneShot(revived);
                H.Life = 2;
                H.PM.Alive = true;
                H.PM.Speed = 10;
                H.HelpMe.SetActive(false);
                StartCoroutine("GetLost");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playersNear--;

            if(playersNear < 1)
            {
                PM = null;
                StopCoroutine("Heal");
                Green.SetActive(false);
                Countdown = 6;
            }
        }
    }

    IEnumerator Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Countdown--;
        }
    }

    IEnumerator GetLost()
    {
        Countdown = 6;
        yield return new WaitForSeconds(0.1f);
        Green.SetActive(false);
        gameObject.SetActive(false);
    }
}