using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorShowUI : MonoBehaviour
{
    public GameObject SensorUI;
    public Material LineMaterial;
    // Start is called before the first frame update
    void Start()
    {
        SensorManager.allSensors.Add(this);
    }
    public void BoxOnClick()
    {
        var board = GameObject.Instantiate(SensorUI);
        board.transform.parent = this.gameObject.transform;
        // DrawLine(this.gameObject.transform.TransformPoint(Vector3.zero), board.transform.TransformPoint(Vector3.zero), Color.green);
        DrawLine(this.gameObject.transform.position, board.transform.position, Color.green);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject("Line");
        myLine.transform.parent = this.gameObject.transform;
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = LineMaterial;
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        // GameObject.Destroy(myLine, duration);
    }
}
