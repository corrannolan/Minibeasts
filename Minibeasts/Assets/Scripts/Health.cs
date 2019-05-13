using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public PlayerMove PM;

    public GameObject ReviveBubble;
    public GameObject HelpMe;

    public int Life;

    void Start()
    {
        PM = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (Life <= 0)
        {
            PM.Alive = false;
            PM.Speed = 1;
            ReviveBubble.SetActive(true);
            HelpMe.SetActive(true);
        }
    }
}