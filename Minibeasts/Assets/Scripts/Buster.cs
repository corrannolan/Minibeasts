using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buster : MonoBehaviour
{
    public GameObject PS;

    public AudioSource aS;
    public AudioClip wallSmash, zDeath;
    public GameObject Blood;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            aS.PlayOneShot(wallSmash);
            GameObject ps = Instantiate(PS, transform.position, new Quaternion());
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Zombie")
        {
            aS.PlayOneShot(zDeath);
            GameObject ps = Instantiate(Blood, transform.position, new Quaternion());
            Destroy(other.gameObject);
        }
    }
}