using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStrand : MonoBehaviour
{
    public GameObject lineObj;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 desPos;

    float timeA;
    public float timeMod;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        timeA = 0;
    }

    // Update is called once per frame
    void Update()
    {
        endPos = new Vector3(lineObj.transform.localPosition.x, lineObj.transform.localPosition.y, lineObj.transform.localPosition.z/2);

        desPos = new Vector3(endPos.x, endPos.y, (endPos.z * timeA)/timeMod);

        if(timeMod > 0)
        {
            if (desPos.z < endPos.z)
            {
                timeA += Time.deltaTime;
                transform.localPosition = new Vector3(desPos.x, lineObj.transform.position.y, desPos.z);
                transform.localScale = new Vector3(1.6f, 0.1f, desPos.z);
            }
        }
        else if(timeMod < 0)
        {
            if(timeA > 0.1f)
            {
                timeA -= Time.deltaTime;
                transform.localPosition = new Vector3(desPos.x, lineObj.transform.position.y, desPos.z);
                transform.localScale = new Vector3(1.6f, 0.1f, desPos.z);
            }
        }

    }
}
