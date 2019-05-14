using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SensorUI {
    public class SensorA : SensorBase {
        // Update is called once per frame
        void Update () { }
        public override void ShowUI () {
            sensorUI.gameObject.SetActive (true);
            string[] inputData = new string[3] { "點膠機稼動率", "19", "-1" }; // name, staus, var
            sensorUI.Show (inputData);
            DrawLine ();
        }

        public override void CloseUI () {
            sensorUI.Close ();
        }
    }
}