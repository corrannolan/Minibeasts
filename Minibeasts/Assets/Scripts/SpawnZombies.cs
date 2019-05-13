using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public GameObject Zombie;
    public float SpawnRate;

    void Awake()
    {
        StartCoroutine("Spawning");
    }

    void Start()
    {

    }

    IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            GameObject gameObject = Instantiate(Zombie, transform.position, transform.rotation);
        }
    }
}