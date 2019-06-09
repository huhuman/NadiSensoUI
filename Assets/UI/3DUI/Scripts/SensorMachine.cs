using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SensorUI
{
    public class SensorMachine : SensorBase
    {
        // Update is called once per frame
        void Update() { }
        public override void ShowUI()
        {
            sensorUI.gameObject.SetActive(true);
            string[] inputData = new string[3] { "錫膏印刷機\n稼動率", "35", "1" }; // icon, value, unit
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