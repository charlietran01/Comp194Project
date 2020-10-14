using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public GameObject water;
    public GameObject leftKnob;
    public GameObject rightKnob;
    float transformFactor;
    
    // Start is called before the first frame update
    void Start()
    {
        water.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (leftKnob.transform.eulerAngles.y >= 45 || rightKnob.transform.eulerAngles.y <= 135)
        {
            water.SetActive(true);
            transformFactor = System.Math.Max(leftKnob.transform.eulerAngles.y, (rightKnob.transform.eulerAngles.y * -1) + 180)/45;
            water.transform.localScale = Vector3.Scale(water.transform.localScale, new Vector3(transformFactor, 1, transformFactor));
        }
        else
        {
            water.SetActive(false);
        }
    }
}
