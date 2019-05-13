using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SensorUI
{


    public class Main : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 200.0f))
                {
                    var hitSensor = hit.transform.GetComponent<SensorBase>();
                    if (hitSensor != null)
                    {
                        SensorManagerBase.Instance.ShowUI(hitSensor.sensorType);
                        Debug.Log("Click on: " + hitSensor.sensorType);
                    }
                }
            }
        }
    }
}
