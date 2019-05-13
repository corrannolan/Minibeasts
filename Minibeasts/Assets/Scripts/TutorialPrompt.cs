using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPrompt : MonoBehaviour
{
    public GameObject Hint;
    public GameObject Bug;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerStay(Collider other)
    {
            if (other.gameObject == Bug)
            {
                Hint.SetActive(true);
            }
        }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Bug)
        {
            Hint.SetActive(false);
        }
    }
    }