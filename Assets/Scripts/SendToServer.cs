using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SendToServer : MonoBehaviour
{
    public List<int> TrialList { get; set; } = new List<int>();
    public List<float> RestTimeList { get; set; } = new List<float>();
    public List<int> LeftInputList { get; set; } = new List<int>();
    public List<int> RightInputList { get; set; } = new List<int>();
    public List<Vector2> LeftPosList { get; set; } = new List<Vector2>();
    public List<Vector2> RightPosList { get; set; } = new List<Vector2>();
    public List<Vector2> TargetPosList { get; set; } = new List<Vector2>();
    public List<int> LineNumList { get; set; } = new List<int>();
    public List<int> ErrorNumList { get; set; } = new List<int>();
    public List<bool> SucceededList { get; set; } = new List<bool>();
    private string _label = "";

    private string _Title;
    [SerializeField] string filename;
    // Start is called before the first frame update
    void Start()
    {
        string _Title = "Day" + System.DateTime.Now.Day.ToString() + "_" + System.DateTime.Now.Hour.ToString() + "h_" + System.DateTime.Now.Minute.ToString() + "min_" + System.DateTime.Now.Second.ToString() + "sec.csv";

        _label += "Trial" + "," + "RestTime";
        _label += "," + "LeftInput" + "," + "RightInput";
        _label += "," + "LeftPos_x" + "," + "LeftPos_y";
        _label += "," + "RightPos_x" + "," + "RightPos_y";
        _label += "," + "TargetPos_x" + "," + "TargetPos_y";
        _label += "," + "LineNum" + "," + "\n";
        
    }

    public void WriteCSV(string line)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/StreamingAssets/" + filename + "_" + _Title + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(line);
        streamWriter.Flush();
        streamWriter.Close();
    }
    public string WritingToServer()
    {
        for (int i = 0; i < LeftInputList.Count; i++)
        {
            _label += TrialList[i].ToString() + "," + RestTimeList[i].ToString();
            _label += "," + LeftInputList[i].ToString() + "," + RightInputList[i].ToString();
            _label += "," + LeftPosList[i].x.ToString() + "," + LeftPosList[i].y.ToString();
            _label += "," + RightPosList[i].x.ToString() + "," + RightPosList[i].y.ToString();
            _label += "," + TargetPosList[i].x.ToString() + "," + TargetPosList[i].y.ToString();
            _label += "," + LineNumList[i].ToString() + "," + "\n";
        }
        return _label;
    }

}
