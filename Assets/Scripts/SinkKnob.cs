using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkKnob : MonoBehaviour
{
    float previousY;
    Vector3 knobEulers;
    bool handTouching;
    bool handColliding;
    GameObject hand;
    
    // Start is called before the first frame update
    void Start()
    {
        handTouching = false;
        knobEulers = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (handColliding)
        {
            if (hand.tag == ("LeftHand") && Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") >= 0.30 || hand.tag == ("RightHand") && Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger") >= 0.30)
            {
                if (handTouching)
                {
                    Debug.Log("handTouching if statement");
                    knobEulers += new Vector3(0, knobEulers.y - previousY, 0);
                }
                else
                {
                    handTouching = true;
                }
                previousY = knobEulers.y;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("LeftHand") || other.tag == ("RightHand"))
        {
            hand = other.gameObject;
            handColliding = true;
            Debug.Log("OnTriggerEnter");
        }
    }

    void OnTriggerExit(Collider other)
    {
        handTouching = false;
        handColliding = false;
        hand = null;
        Debug.Log("OnTriggerExit");
    }
}
