using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public List<int> TrialList { get; set; } = new List<int>();
    public List<float> RestTimeList { get; set; } = new List<float>();
    public List<int> LeftInputList { get; set; } = new List<int>();
    public List<int> RightInputList { get; set; } = new List<int>();
    public List<Vector2> LeftPosList { get; set; } = new List<Vector2>();
    public List<Vector2> RightPosList { get; set; } = new List<Vector2>();
    public List<Vector2> TargetPosList { get; set; } = new List<Vector2>();
    public List<int> NumList { get; set; } = new List<int>();
    [SerializeField] CSVWriter _CSVWriter;

    string InitialText = "Trial" + "," + "RestTime" + ","
        + "LeftInput" + "," + "RightInput"
        + "," + "LeftPos_x" + "," + "LeftPos_y"
        + "," + "RightPos_x" + "," + "RightPos_y"
        + "," + "TargetPos_x" + "," + "TargetPos_y"
        + "," + "LineNum" + "," + "\n";


    public void WritingToServer()
    {
        string _content = InitialText;
        for (int i = 0; i < LeftInputList.Count; i++)
        {
            _content += TrialList[i].ToString() + "," + RestTimeList[i].ToString();
            _content += "," + LeftInputList[i].ToString() + "," + RightInputList[i].ToString();
            _content += "," + LeftPosList[i].x.ToString() + "," + LeftPosList[i].y.ToString();
            _content += "," + RightPosList[i].x.ToString() + "," + RightPosList[i].y.ToString();
            _content += "," + TargetPosList[i].x.ToString() + "," + TargetPosList[i].y.ToString();
            _content += "," + NumList[i].ToString() + "," + "\n";
        }
        _CSVWriter.WriteCSV(_content);
    }
}
