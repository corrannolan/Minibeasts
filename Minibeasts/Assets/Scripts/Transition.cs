using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject BlackScreen;
    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public GameObject PlayerThree;
    public GameObject PointOne;
    public GameObject PointTwo;
    public GameObject PointThree;
    public bool AlreadyHit = false;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!AlreadyHit)
            {
                AlreadyHit = true;
                BlackScreen.SetActive(true);
                StartCoroutine("Teleport");
            }
        }
    }
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerOne.transform.position = PointOne.transform.position;
        PlayerTwo.transform.position = PointTwo.transform.position;
        PlayerThree.transform.position = PointThree.transform.position;
    }
}