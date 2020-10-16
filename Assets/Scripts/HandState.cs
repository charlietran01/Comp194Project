using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState : MonoBehaviour
{
    public GameObject dirtPrefab;
    List<GameObject> dirtList;
    bool isDirty;
    bool dirtOnHand;
    bool inWater;
    bool cleaning;
    float waterTime;
    float destroyTimer;
    int handFlip;
    
    // Start is called before the first frame update
    void Start()
    {
        isDirty = true;
        dirtOnHand = false;
        handFlip = 1;
        inWater = false;
        cleaning = false;
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
                dirtList = new List<GameObject>();
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).gameObject.tag == "Dirt")
                    {
                        dirtList.Add(transform.GetChild(i).gameObject);
                    }
                }
                foreach (GameObject dirt in dirtList)
                {
                    Debug.Log(dirt);
                }
                dirtOnHand = true;
            }
            if (inWater && waterTime >= 5)
            {
                isDirty = false;
                cleaning = true;
            }
            // isDirty = false;
            // cleaning = true;

        }
        else
        {
            if (dirtOnHand)
            {
                if (cleaning)
                {
                    foreach (GameObject dirt in dirtList)
                    {
                        dirt.AddComponent<Rigidbody>();
                        dirt.transform.SetParent(null);
                    }
                    // transform.Find("DirtSphere(Clone)").gameObject.AddComponent<Rigidbody>();
                    // transform.Find("DirtSphere(Clone)").SetParent(null);
                    cleaning = false;
                    Debug.Log("rigidbodies added");
                }
                destroyTimer += Time.deltaTime;
                if (destroyTimer >= 5)
                {
                    foreach (GameObject dirt in dirtList)
                    {
                        Object.Destroy(dirt);
                    }
                    // Object.Destroy(transform.Find("DirtSphere(Clone)").gameObject);
                    Debug.Log("Dirt destroyed");
                    destroyTimer = 0;
                    dirtOnHand = false;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (inWater)
        {
            waterTime += Time.deltaTime;
            Debug.Log(waterTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            inWater = true;
            Debug.Log("Touching Water");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            inWater = false;
            Debug.Log("Not touching water");
        }
    }
}
