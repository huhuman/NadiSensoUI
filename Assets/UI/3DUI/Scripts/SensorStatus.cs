using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SensorUI
{
    public class SensorStatus : SensorBase
    {
        // Update is called once per frame
        void Update() { }
        public override void ShowUI()
        {
            sensorUI.gameObject.SetActive(true);
            string[] inputData = new string[2] { "status", "異常" }; // icon, value, unit
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