using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public GameObject Zombie;
    public float SpawnRate;
    //public float SpawnSpan;

    void Start()
    {
    }
    void Awake()
    {
            StartCoroutine("Spawning");
            //StartCoroutine("GooGooGaGa");
}
    IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            GameObject gameObject = Instantiate(Zombie, transform.position, transform.rotation);
        }
    }
    /*IEnumerator GooGooGaGa()
    {
        yield return new WaitForSeconds(SpawnSpan);
        Destroy(gameObject);
    }*/
}