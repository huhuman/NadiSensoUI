using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SensorUI
{
    public class MachineUI : SensorUIBase
    {
        public Text context;
        public Text availability_properity;
        public Image status;

        public override void Show(string[] data)
        {
            context.text = data[0];
            availability_properity.text = data[1];
            if (data[2].Equals("1"))
            {
                status.color = Color.red;
            }
        }
        public override void Close()
        {
            this.gameObject.SetActive(false);
        }
    }
}