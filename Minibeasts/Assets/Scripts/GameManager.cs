using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMove[] players;

    public bool[] livingP;

    public int currentLevel;
    public int startScreen;

    public float relDel;
    bool reloading = false;

    int pNum = 0;
    int lPNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (PlayerMove pM in players)
        {
            if(pM.Alive == false)
            {
                livingP[pNum] = false;
            }
            else if(pM.Alive == true)
            {
                livingP[pNum] = true;
            }

            pNum++;

            if (pNum > 2)
            {
                pNum = 0;
            }
        }

        foreach(bool check in livingP)
        {
            if(check == true)
            {
                lPNum++;
            }
            else
            {
                lPNum--;
            }
        }

        if(lPNum < -2)
        {
            ReloadL();
        }

        lPNum = 0;
    }

    void ReloadL()
    {
        if(reloading == false)
        {
            reloading = true;
            StartCoroutine(reloadLevel());
        }
    }

    public void Restart()
    {
        StartCoroutine(restartGame());
    }

    IEnumerator reloadLevel()
    {
        yield return new WaitForSeconds(relDel);
        SceneManager.LoadScene(currentLevel);
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(startScreen);
    }
}
