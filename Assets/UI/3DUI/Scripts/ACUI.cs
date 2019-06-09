using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SensorUI
{
    public class ACUI : SensorUIBase
    {
        public Text context;
        public Text availability_properity;
        public Text unit_properity;

        public override void Show(string[] data)
        {
            context.text = data[0];
            availability_properity.text = data[1];
            unit_properity.text = data[2];
        }
        public override void Close()
        {
            this.gameObject.SetActive(false);
        }
    }
}