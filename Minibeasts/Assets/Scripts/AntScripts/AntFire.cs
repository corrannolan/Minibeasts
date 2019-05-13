using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntFire : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip thornBurn, zDeath;
    public GameObject Blood;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Thorns")
        {
            aS.PlayOneShot(thornBurn);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Zombie")
        {
            aS.PlayOneShot(zDeath);
            GameObject ps = Instantiate(Blood, transform.position, new Quaternion());
            Destroy(other.gameObject);
        }
    }
}