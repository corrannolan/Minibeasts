using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCollisions : MonoBehaviour
{
    //public GameObject kinBody;
    Vector3 startPos;
    Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.localPosition;
        startRot = gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = startPos;
        gameObject.transform.localRotation = startRot;
    }
}
