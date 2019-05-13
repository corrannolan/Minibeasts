using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class SpiderNew : MonoBehaviour
{
    Player player;

    PlayerMove pM;

    Rigidbody rB;

    public GameObject lineObj;
    Vector3 lineStart;

    RaycastHit anchorHit;
    public GameObject spinner;
    Vector3 anchorPoint;
    Vector3 midRay, leftRay, rightRay;
    public float lineLength;
    bool rayOn = true;
    bool isAnchored = false;

    public bool canLine = true;
    public GameObject lineStrand;
    SpiderStrand sS;
    public float lineDel;

    // Start is called before the first frame update
    void Start()
    {
        pM = GetComponent<PlayerMove>();
        player = ReInput.players.GetPlayer(pM.PlayerID);

        rB = GetComponent<Rigidbody>();

        sS = lineStrand.GetComponentInChildren<SpiderStrand>();

        lineStart = lineObj.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(rayOn == true)
        {
            Vector3 rayMod = new Vector3(transform.right.x * 0.6f, transform.right.y, transform.right.z * 0.6f);

            midRay = spinner.transform.position;
            leftRay = new Vector3(spinner.transform.position.x - rayMod.x, spinner.transform.position.y, spinner.transform.position.z - rayMod.z);
            rightRay = new Vector3(spinner.transform.position.x + rayMod.x, spinner.transform.position.y, spinner.transform.position.z + rayMod.z);
        }

        if (player.GetButtonDown("Ability"))
        {
            LineOut();
        }
        else if (player.GetButtonUp("Ability"))
        {
            LineBack();
        }

        Debug.DrawRay(midRay, spinner.transform.forward * lineLength, Color.magenta);
        Debug.DrawRay(leftRay, spinner.transform.forward * lineLength, Color.magenta);
        Debug.DrawRay(rightRay, spinner.transform.forward * lineLength, Color.magenta);
    }

    void LineOut()
    {
        if (Physics.Raycast(midRay, spinner.transform.forward, out anchorHit, lineLength))
        {
            if (anchorHit.collider.gameObject.tag == "Player")
            {
                anchorPoint = new Vector3(anchorHit.transform.position.x - 1, anchorHit.transform.position.y, anchorHit.transform.position.z - 1);
            }
            else if (anchorHit.collider.gameObject.tag == "Anchor")
            {
                anchorPoint = new Vector3(anchorHit.transform.position.x, anchorHit.transform.position.y, anchorHit.transform.position.z);
                isAnchored = true;
            }
        }
        else if (Physics.Raycast(leftRay, spinner.transform.forward, out anchorHit, lineLength))
        {
            if (anchorHit.collider.gameObject.tag == "Player")
            {
                anchorPoint = new Vector3(anchorHit.transform.position.x - 1, anchorHit.transform.position.y, anchorHit.transform.position.z - 1);
            }
            else if (anchorHit.collider.gameObject.tag == "Anchor")
            {
                anchorPoint = new Vector3(anchorHit.transform.position.x, anchorHit.transform.position.y, anchorHit.transform.position.z);
                isAnchored = true;
            }
        }
        else if (Physics.Raycast(rightRay, spinner.transform.forward, out anchorHit, lineLength))
        {
            if (anchorHit.collider.gameObject.tag == "Player")
            {
                anchorPoint = new Vector3(anchorHit.transform.position.x - 1, anchorHit.transform.position.y, anchorHit.transform.position.z - 1);
            }
            else if (anchorHit.collider.gameObject.tag == "Anchor")
            {
                anchorPoint = new Vector3(anchorHit.transform.position.x, anchorHit.transform.position.y, anchorHit.transform.position.z);
                isAnchored = true;
            }
        }
        else
        {
            anchorPoint = spinner.transform.forward * lineLength;
        }

        if (canLine == true)
        {
            canLine = false;

            rB.constraints = RigidbodyConstraints.FreezeAll;

            lineObj.transform.position = anchorPoint;

            if(sS.timeMod < 0)
            {
                sS.timeMod = -sS.timeMod;
            }
            lineStrand.SetActive(true);

            rayOn = false;

            if(isAnchored == false)
            {
                NoAnchor();
            }
        }
    }

    void NoAnchor()
    {
        StartCoroutine(fullExtend());
    }

    IEnumerator fullExtend()
    {
        yield return new WaitForSeconds(sS.timeMod);

        LineBack();
    }

    void LineBack()
    {
        StartCoroutine(lineDelay());
    }

    IEnumerator lineDelay()
    {
        lineObj.transform.localPosition = lineStart;
        if (sS.timeMod > 0)
        {
            sS.timeMod = -sS.timeMod;
        }

        yield return new WaitForSeconds(sS.timeMod);

        lineStrand.SetActive(true);

        rB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rayOn = true;

        yield return new WaitForSeconds(lineDel);

        canLine = true;
    }
}
