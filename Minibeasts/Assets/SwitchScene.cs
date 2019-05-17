using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class SwitchScene : MonoBehaviour {

    public string Scene;

    void Start() {
    }
    void Update() {
        if (Input.anyKey)
        {
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel(Scene);
    }
}