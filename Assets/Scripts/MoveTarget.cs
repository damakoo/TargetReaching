using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] public float SettingTime = 30;
    [SerializeField] GameObject Cursor;
    [SerializeField] GameObject Canbus;
    [SerializeField] GameObject Child;
    [SerializeField] TextMeshProUGUI InTargetGUI;
    [SerializeField] TextMeshProUGUI DistanceGUI;
    public float RestTime { get; set; }
    public bool isTracing = false;
    public bool isFinishied = false;
    

    // Start is called before the first frame update
    void Start()
    {
        RestTime = SettingTime;
        Canbus.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isTracing)
        {
            Canbus.SetActive(false);

        }
        if(isTracing)
        {

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isTracing = false;
            RestTime = SettingTime;
        }
    }
}
