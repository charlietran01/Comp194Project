using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public GameObject water;
    public GameObject leftKnob;
    public GameObject rightKnob;
    float transformFactor;
    Vector3 originalWater;
    
    // Start is called before the first frame update
    void Start()
    {
        water.SetActive(false);
        originalWater = new Vector3(0.01f, 0.2000392f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rightKnob.transform.localEulerAngles.y >= 35 || leftKnob.transform.localEulerAngles.y <= 145)
        {
            Debug.Log("Right knob rotation: " + rightKnob.transform.localEulerAngles.y);
            Debug.Log("Left knob rotation: " + leftKnob.transform.localEulerAngles.y);
            water.SetActive(true);
            Debug.Log("Water on!");
            transformFactor = System.Math.Max(rightKnob.transform.eulerAngles.y, (leftKnob.transform.eulerAngles.y * -1) + 180)/35;
            water.transform.localScale = Vector3.Scale(originalWater, new Vector3(transformFactor, 1, transformFactor));
            Debug.Log("Water transform factor: " + transformFactor);
        }
        else
        {
            water.SetActive(false);
        }
    }
}
