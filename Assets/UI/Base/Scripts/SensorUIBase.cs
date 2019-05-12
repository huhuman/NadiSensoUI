using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SensorUI {
    public class SensorUIBase : MonoBehaviour {

        // 覆寫收到資料後各 UI 怎麼繪製資料
        public virtual void Show (string[] data) {
            // TODO
            // 透過模擬的資料，把資料顯示在對應的UI上
        }
        // 覆寫UI關閉
        public virtual void Close () {
            // TODO
        }
    }
}