using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Mite : MonoBehaviour
{
    PlayerMove pM;
    Player player;

    public Rigidbody rB;

    public GameObject spawnPoint;
    public GameObject expPrefab;

    bool following = true;

    public bool release = false;
    public float speed;
    public bool bomb = false;
    public bool fuse = false;

    public float fuseTime;

    AudioSource aS;
    public AudioClip exp;

    // Start is called before the first frame update
    void Start()
    {
        pM = GetComponent<PlayerMove>();

        player = ReInput.players.GetPlayer(pM.PlayerID);

        rB = GetComponent<Rigidbody>();

        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Ability"))
        {
            Explode();
        }
    }

    public void Mission()
    {
        Light();
    }

    void Light()
    {
        StartCoroutine(fuseLit());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 18 || collision.gameObject.layer == 17)
        {
            if (fuse == false)
            {
                fuse = true;
                Explode();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ControlArea")
        {
            fuse = true;
            Explode();
        }
    }

    IEnumerator fuseLit()
    {
        yield return new WaitForSeconds(fuseTime);
        Explode();
    }

    void Explode()
    {
        StartCoroutine(explosion());
    }

    IEnumerator explosion()
    {
        aS.PlayOneShot(exp);
        yield return new WaitForSeconds(0.25f);
        Instantiate(expPrefab, spawnPoint.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
