using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    public GameObject HiveOne;
    public GameObject HiveTwo;
    public GameObject HiveThree;
    public string TheEnd;
    GrossZBall GZB;
    GrossZBall GZBT;
    GrossZBall GZBTH;

    void Start()
    {
        GZB = HiveOne.GetComponent<GrossZBall>();
        GZBT = HiveTwo.GetComponent<GrossZBall>();
        GZBTH = HiveThree.GetComponent<GrossZBall>();
    }
    void Update()
    {
        if (GZB.Yeeted == true && GZBT.Yeeted == true && GZBTH.Yeeted == true)
        {
            StartCoroutine("OldSpiceManBodySpray");
        }
    }
    IEnumerator OldSpiceManBodySpray()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel(TheEnd);
    }
}