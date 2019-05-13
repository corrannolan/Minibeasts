using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pud : MonoBehaviour
{
    public float desTime;

    public AudioSource aS;
    public AudioClip zDeath;
    public GameObject Blood;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            aS.PlayOneShot(zDeath);
            GameObject ps = Instantiate(Blood, transform.position, new Quaternion());
            Destroy(other.gameObject);
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(desTime);
        Destroy(gameObject);
    }
}
