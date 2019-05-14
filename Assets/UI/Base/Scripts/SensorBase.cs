using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SensorUI {
    [RequireComponent (typeof (LineRenderer))]
    public class SensorBase : MonoBehaviour {
        [Header ("Sensor 名稱")]
        public string sensorType;
        [Header ("Sensor UI")]
        public SensorUIBase sensorUI;
        [Header ("資料ID")]
        public int dataId;
        protected LineRenderer lineRenderer;

        // sensor把自己透過sensor類型註冊到管理器內
        protected virtual void Awake () {
            SensorManagerBase.Instance.AddSensor (sensorType, this);
            lineRenderer = this.GetComponent<LineRenderer> ();
        }

        // 複寫顯示 UI 時該怎麼拿資料及處理資料並顯示UI與把資料指定給UI，可能會有的額外功能是顯示動畫
        public virtual void ShowUI () {
            // TODO
            // 可以先模擬需要的資料，例如 data=["20度"]。如果之後收到的資料格式不是string[]，就也在這部份把資料處理成string[]
            // 然後打開UI並呼叫sensorUI.Show(data)
        }
        // 複寫關閉 UI ，可能會有的額外功能是關閉動畫
        public virtual void CloseUI () {
            // TODO
        }
        protected virtual void DrawLine () {
            lineRenderer.SetPosition (0, this.transform.position);
            lineRenderer.SetPosition (1, sensorUI.transform.position);
        }
    }
}