using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public GameObject pudPrefab;

    public float expMod;
    public float puddleSize;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + expMod, transform.localScale.y + expMod, transform.localScale.z + expMod);

        if(transform.localScale.x >= puddleSize)
        {
            Puddle();
        }
    }

    void Puddle()
    {
        Instantiate(pudPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
