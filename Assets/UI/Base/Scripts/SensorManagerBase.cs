using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZTools;

namespace SensorUI
{
    public struct Sensor
    {
        public List<SensorBase> sensorList;
    }
    // Sensor管理
    public class SensorManagerBase : Singleton<SensorManagerBase>
    {
        private Dictionary<string, Sensor> sensorDic = new Dictionary<string, Sensor>();

        public void AddSensor(string sensorType, SensorBase sensorBase)
        {
            if (!this.sensorDic.ContainsKey(sensorType))
            {
                Sensor sensor = new Sensor();
                sensor.sensorList = new List<SensorBase>();
                sensorDic[sensorType] = sensor;
            }
            sensorDic[sensorType].sensorList.Add(sensorBase);
        }
        // 透過管理器來控制所有指定sensor的UI的顯示
        public void ShowUI(string sensorType)
        {
            if (!this.sensorDic.ContainsKey(sensorType))
            {
                ShowMessage(string.Format("Sensor {0} 不存在管理器內", sensorType));
                return;
            }
            foreach (var sensor in this.sensorDic[sensorType].sensorList)
            {
                sensor.ShowUI();
            }
        }
        // 透過管理器來控制所有指定sensor的UI的關閉
        public void CloseUI(string sensorType)
        {
            if (!this.sensorDic.ContainsKey(sensorType))
            {
                ShowMessage(string.Format("Sensor {0} 不存在管理器內", sensorType));
                return;
            }
            foreach (var sensor in this.sensorDic[sensorType].sensorList)
            {
                sensor.CloseUI();
            }
        }
    }
}