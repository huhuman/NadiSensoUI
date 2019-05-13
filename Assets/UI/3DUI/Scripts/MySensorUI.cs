using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SensorUI
{
    public class MySensorUI : SensorUIBase
    {
        public override void Show(string[] data)
        {
            string name = data[0];
            int value = System.Int32.Parse(data[1]);
            int status = System.Int32.Parse(data[2]);
        }
        public override void Close()
        {
            Destroy(this.gameObject);
        }
    }
}
