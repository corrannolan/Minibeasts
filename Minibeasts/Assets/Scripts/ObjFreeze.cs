using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFreeze : MonoBehaviour
{
    Rigidbody rB;

    public bool canRot;
    public bool rotZ;

    AudioSource aS;
    public AudioClip groundCol;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();

        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)
        {
            aS.PlayOneShot(groundCol);

            if(canRot == true)
            {
                if (rotZ == false)
                    rB.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                else if (rotZ == true)
                    rB.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }
            else
            {
                rB.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
