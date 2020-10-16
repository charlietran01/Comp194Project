using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState : MonoBehaviour
{
    public GameObject dirtPrefab;
    bool isDirty;
    bool dirtOnHand;
    int handFlip;
    
    // Start is called before the first frame update
    void Start()
    {
        isDirty = true;
        dirtOnHand = false;
        handFlip = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDirty)
        {
            if (!dirtOnHand)
            {
                if (gameObject.tag == "LeftHand")
                {
                    handFlip = -1;
                }
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.05844998f * handFlip, -0.02250004f, -0.0662000f);
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.02189994f * handFlip, -0.04050004f, -0.03750002f);
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.0187f * handFlip, -0.05710006f, -0.05540001f);
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.02469993f * handFlip, -0.05710006f, -0.02610004f);
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.02389991f * handFlip, -0.02400005f, -0.02090001f);
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.058f * handFlip, -0.02272f, -0.0281f);
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.0453999f * handFlip, -0.0005999804f, -0.074f);
                Instantiate(dirtPrefab, transform.position, transform.rotation, transform).transform.localPosition += new Vector3(0.0453999f * handFlip, -0.003300071f, -0.04250002f);
                dirtOnHand = true;
            }
        }
        else
        {
            if (dirtOnHand)
            {

            }
        }
    }
}
