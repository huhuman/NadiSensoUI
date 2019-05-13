using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SensorUI
{
    public class MySensor : SensorBase
    {
        public Material LineMaterial;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }
        public override void ShowUI()
        {
            var board = GameObject.Instantiate(sensorUI.gameObject);
            string[] inputData = new string[3] { "點膠機稼動率", "98", "-1" }; // name, staus, var
            sensorUI.Show(inputData);
            board.transform.parent = this.gameObject.transform;
            DrawLine(this.gameObject.transform.position, sensorUI.gameObject.transform.position, Color.green);
        }

        public override void CloseUI()
        {
            sensorUI.Close();
        }
        void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
        {
            GameObject myLine = new GameObject("Line");
            myLine.transform.parent = this.gameObject.transform;
            myLine.transform.position = start;
            myLine.AddComponent<LineRenderer>();
            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.material = LineMaterial;
            lr.startColor = color;
            lr.endColor = color;
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
            // GameObject.Destroy(myLine, duration);
        }
    }
}
