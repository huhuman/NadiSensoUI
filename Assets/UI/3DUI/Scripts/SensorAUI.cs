using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SensorUI {
    public class SensorAUI : SensorUIBase {
        public Text availability_properity;

        public override void Show (string[] data) {
            string name = data[0];
            int value = System.Int32.Parse (data[1]);
            int status = System.Int32.Parse (data[2]);
            availability_properity.text = data[1];
        }
        public override void Close () {
            this.gameObject.SetActive (false);
        }
    }
}