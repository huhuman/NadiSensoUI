using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    public static List<SensorShowUI> allSensors = new List<SensorShowUI>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (var sensor in allSensors)
            {
                sensor.BoxOnClick();
            }
        }
    }
}
