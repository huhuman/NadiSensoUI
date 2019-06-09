using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SensorUI
{
    public class SensorAC : SensorBase
    {
        // Update is called once per frame
        void Update() { }
        public override void ShowUI()
        {
            sensorUI.gameObject.SetActive(true);
            string[] inputData = new string[3] { "冷卻水\n溫度", "20", "°C" };
            sensorUI.Show(inputData);
            lineRenderer.enabled = true;
        }

        public override void CloseUI()
        {
            lineRenderer.enabled = false;
            sensorUI.Close();
        }
    }
}