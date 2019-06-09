using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SensorUI
{
    public class StatusUI : SensorUIBase
    {
        public Image icon_property;
        public Text availability_properity;

        public override void Show(string[] data)
        {
            Sprite icon_sprite = Resources.Load<Sprite>(data[0]);
            icon_property.sprite = icon_sprite;
            availability_properity.text = data[1];
        }
        public override void Close()
        {
            this.gameObject.SetActive(false);
        }
    }
}