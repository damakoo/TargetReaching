using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultRecorder : MonoBehaviour
{
    [SerializeField] CSVWriter _CSVWriter;
    [SerializeField] TargetReachingManager _targetReachingManager;

    string InitialText = "Trial" + "," + "Result" + "\n";


    public void WritingToServer()
    {
        string _content = InitialText;
        for (int i = 0; i < _targetReachingManager.result.Count; i++)
        {
            _content += i.ToString() + "," + _targetReachingManager.result[i].ToString() + "\n";
        }
        _CSVWriter.WriteCSV(_content);
    }
}
