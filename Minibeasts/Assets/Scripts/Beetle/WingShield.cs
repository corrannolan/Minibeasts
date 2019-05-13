using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingShield : MonoBehaviour
{
    Boulder BScript;

    public GameObject PS;

    public AudioSource aS;
    public AudioClip shieldDes;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            aS.PlayOneShot(shieldDes);
            Destroy(other.gameObject);
            GameObject ps = Instantiate(PS, transform.position, new Quaternion());
        }

        if (other.gameObject.layer == 23)
        {
            aS.PlayOneShot(shieldDes);
            BScript = other.GetComponent<Boulder>();
            other.GetComponent<Renderer>().material = BScript.Red;
        }
    }
}