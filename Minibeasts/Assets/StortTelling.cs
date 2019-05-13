using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StortTelling : MonoBehaviour
{
    public string Scene;

    void Start()
    {
        StartCoroutine("OK");
    }
    void Update()
    {
    }
    IEnumerator OK()
    {
        yield return new WaitForSeconds(15);
        Application.LoadLevel(Scene);

    }
}