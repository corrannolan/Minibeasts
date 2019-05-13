using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Spider : MonoBehaviour
{
    Player player;

    PlayerMove pM;
    Rigidbody rB;

    public SpiderStrand sS;

    public GameObject spinner;
    public GameObject lineObj;
    Vector3 lineStart;
    Vector3 leftStart;
    Vector3 rightStart;
    public GameObject strandObj;

    public float targetLength;
    RaycastHit anchorPoint;
    RaycastHit left;
    RaycastHit right;
    Vector3 anchor;

    public bool canLine = true;
    bool raysOn = true;
    bool anchored = false;
    public float lineTime;
    public float lineDel;
    public bool CanWeb = false;
    public bool ReadyToWeb = true;
    public GameObject Trampoline;
    public GameObject TSpawn;

    // Start is called before the first frame update
    void Start()
    {
        pM = GetComponent<PlayerMove>();

        player = pM.player;

        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(raysOn == true)
        {
            lineStart = lineObj.transform.position;
            leftStart = new Vector3(lineObj.transform.position.x - (0.6f * transform.right.x), lineObj.transform.position.y, lineObj.transform.position.z - (0.6f * transform.right.z));
            rightStart = new Vector3(lineObj.transform.position.x + (0.6f * transform.right.x), lineObj.transform.position.y, lineObj.transform.position.z + (0.6f * transform.right.z));

            if (Physics.Raycast(lineStart, transform.forward, out anchorPoint, targetLength))
            {
                if (anchorPoint.collider.gameObject.tag == "Player")
                {
                    canLine = false;
                }
                else
                {
                    canLine = true;
                }

                if (anchorPoint.collider.gameObject.tag == "Anchor")
                {
                    anchor = anchorPoint.point;
                    print("anchor hit");
                }
                else
                {
                    anchored = false;
                    anchor = new Vector3(transform.forward.x * targetLength, transform.forward.y * targetLength, transform.forward.z * targetLength);
                }
            }
            else if (Physics.Raycast(leftStart, transform.forward, out left, targetLength))
            {
                if (anchorPoint.collider.gameObject.tag == "Player")
                {
                    canLine = false;
                }
                else
                {
                    canLine = true;
                }

                if (anchorPoint.collider.gameObject.tag == "Anchor")
                {
                    anchor = left.point;
                    print("anchor hit");
                }
                else
                {
                    anchored = false;
                    anchor = new Vector3(transform.forward.x * targetLength, transform.forward.y * targetLength, transform.forward.z * targetLength);
                }
            }
            else if (Physics.Raycast(rightStart, transform.forward, out left, targetLength))
            {
                if (anchorPoint.collider.gameObject.tag == "Player")
                {
                    canLine = false;
                }
                else
                {
                    canLine = true;
                }

                if (anchorPoint.collider.gameObject.tag == "Anchor")
                {
                    anchor = right.point;
                    print("anchor hit");
                }
                else
                {
                    anchored = false;
                    anchor = new Vector3(transform.forward.x * targetLength, transform.forward.y * targetLength, transform.forward.z * targetLength);
                }
            }
            else
            {
                anchored = false;
                anchor = new Vector3(transform.forward.x * targetLength, transform.forward.y * targetLength, transform.forward.z * targetLength);
            }

            Debug.DrawRay(lineStart, transform.forward * targetLength, Color.cyan);
            Debug.DrawRay(leftStart, transform.forward * targetLength, Color.cyan);
            Debug.DrawRay(rightStart, transform.forward * targetLength, Color.cyan);
        }
        

        if (pM.player.GetButtonDown("Ability"))
        {
            Line();
        }
        else if (pM.player.GetButtonUp("Ability"))
        {
            NoLine();
        }

        if (CanWeb == true)
        {
            if (ReadyToWeb == true)
            {
                if (pM.player.GetButtonDown("Ability2"))
                {
                    GameObject gameObject = Instantiate(Trampoline, TSpawn.transform.position, new Quaternion());
                    ReadyToWeb = false;
                    StartCoroutine("ChillSpidey");
                }
            }
        }
    }

    void Line()
    {
        if(canLine == true)
        {
            canLine = false;
            raysOn = false;
            pM.Controls = false;
            rB.constraints = RigidbodyConstraints.FreezeAll;

            lineObj.transform.position = anchor;
            lineObj.SetActive(true);
            strandObj.SetActive(true);

            if(anchor == anchorPoint.point)
            {
                anchored = true;
            }
            else
            {
                StartCoroutine(lineDelay());
            }
        }
    }

    void NoLine()
    {
        strandObj.SetActive(false);
        lineObj.SetActive(false);
        lineObj.transform.localPosition = lineStart;

        StartCoroutine(lineDelay());
        rB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        pM.Controls = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SZone")
        {
            CanWeb = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SZone")
        {
            CanWeb = false;
        }
    }

    IEnumerator lineTimer()
    {
        yield return new WaitForSeconds(lineTime);
        if(anchored == false)
        {
            if (strandObj == true)
                NoLine();
        }
    }

    IEnumerator lineDelay()
    {
        yield return new WaitForSeconds(lineDel);
        raysOn = true;
        canLine = true;
    }

    IEnumerator ChillSpidey()
    {
        yield return new WaitForSeconds(24);
        ReadyToWeb = true;
    }
}
