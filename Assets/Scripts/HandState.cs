using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState : MonoBehaviour
{
    public GameObject dirtPrefab;
    bool isDirty;
    bool dirtOnHand;
    
    // Start is called before the first frame update
    void Start()
    {
        isDirty = true;
        dirtOnHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.Find("DirtSphere(Clone)").position);
        if (isDirty)
        {
            if (!dirtOnHand)
            {
                Instantiate(dirtPrefab, new Vector3(-1.8938f, 1.4375f, -1.5388f), new Quaternion(0, 0, 0, 0), transform);
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
