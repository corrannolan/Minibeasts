using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLine : MonoBehaviour
{
    public GameObject strand;
    BoxCollider sBC;
    public GameObject webPrefab;

    Rigidbody rB;

    public bool extend = true;
    public float extSpeed;
    bool timeStarted = false;
    public float extTime;

    public bool unstuck = true;
    Vector3 startPos;
    Vector3 startRot;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();

        sBC = strand.GetComponent<BoxCollider>();

        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(timeStarted == false)
        {
            if (extend == true)
            {
                timeStarted = true;
                TimeStart();

                sBC.enabled = false;
                strand.SetActive(true);
            }
        }

        if (extend == true)
        {
            rB.velocity = new Vector3(transform.forward.x * extSpeed, 0, transform.forward.z * extSpeed);
            rB.useGravity = true;
            transform.localPosition = new Vector3(transform.localPosition.x, startPos.y, transform.localPosition.z);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Anchor")
        {
            rB.velocity = Vector3.zero;
            rB.constraints = RigidbodyConstraints.FreezeAll;
            extend = false;
            unstuck = false;

            sBC.enabled = true;
            print("anchor hit");
        }
        else if(other.gameObject.tag == "Enemy")
        {
            Instantiate(webPrefab, other.transform.position, other.transform.rotation);

            StopAllCoroutines();
            Retract();
        }*/
    }

    /*void TimeStart()
    {
        StartCoroutine(extendTimer());
    }

    IEnumerator extendTimer()
    {
        yield return new WaitForSeconds(extTime);

        if(unstuck == true)
        {
            Retract();
        }
    }

    public void Retract()
    {
        StartCoroutine(retractTimer());

        print("retract");
    }

    IEnumerator retractTimer()
    {
        extend = false;
        rB.constraints = RigidbodyConstraints.None;

        rB.velocity = new Vector3(transform.forward.x * -1.5f * extSpeed, 0, transform.forward.z * -1.5f * extSpeed);

        yield return new WaitForSeconds(transform.localPosition.z / 1.5f / extSpeed);

        rB.useGravity = false;

        strand.transform.localScale = new Vector3(0.25f, 0.1f, 0);
        strand.transform.localPosition = new Vector3(0, -0.45f, 0.1f);
        strand.SetActive(false);

        timeStarted = false;

        transform.localPosition = startPos;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        extend = true;
        gameObject.SetActive(false);
        print("tract");
    }*/
}
