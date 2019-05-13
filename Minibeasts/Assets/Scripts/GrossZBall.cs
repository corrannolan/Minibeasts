using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrossZBall : MonoBehaviour
{
    AudioSource aS;
    public AudioClip hiveDes;
    public bool Yeeted = false;
    Renderer Rend;
    public GameObject Child;
    public GameObject zombie;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        Rend = GetComponent<Renderer>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 16 || other.gameObject.tag == "Horn" || other.gameObject.tag == "Fire")
        {
            Yeeted = true;
            GameObject ps = Instantiate(zombie, transform.position, new Quaternion());
            aS.PlayOneShot(hiveDes);
            StartCoroutine("Die");
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        Rend.enabled = false;
        Destroy(Child);
    }
}