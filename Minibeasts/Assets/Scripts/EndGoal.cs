using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    public string nextLevel;
    private bool AlreadyHit = false;
    public GameObject BlackScreen;

    void Start()
    {
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (!AlreadyHit)
        {
            if (other.gameObject.tag == "Player")
            {
                BlackScreen.SetActive(true);
                AlreadyHit = true;
                StartCoroutine("Finish");
            }
        }
    }
    IEnumerator Finish()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevel);
    }
}