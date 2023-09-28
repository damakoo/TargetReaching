using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetReachingManager : MonoBehaviour
{
    public int numTrial = 10;
    [SerializeField] float CanMoveTime = 5;
    [SerializeField] float ReadyTime = 1;
    [SerializeField] InputRecorder _inputRecorder;
    [SerializeField] ResultRecorder _ResultRecorder;
    [SerializeField] TargetManager _TargetManager;
    [SerializeField] ObstacleManager _ObstacleManager;
    [SerializeField] GameObject textforEnd;
    private int nowTrial = 1;
    private bool isTracing = false;
    public List<float> result { get; set; } = new List<float>();
    private float TrialTime = 0;
    private float timelimit
    {
        get
        {
            return ReadyTime + CanMoveTime;
        }
    }
    private bool isFinished = false;
    [SerializeField] Transform Cursor;
    Rigidbody2D _cursorRigidbody;
    [SerializeField] GameObject RightCursor;
    [SerializeField] GameObject LeftCursor;
    [SerializeField] GameObject RopeParent;
    List<Transform> RopeChildrenTransform = new List<Transform>();
    List<Vector3> RopeChildrenfirstPosition = new List<Vector3>();
    List<Quaternion> RopeChildrenfirstQuaternion = new List<Quaternion>();
    private Vector3 firstCursorPos;
    private Vector3 firstRightCursorPos;
    private Vector3 firstLeftCursorPos;
    private Quaternion firstCursorRot;
    private Quaternion firstRightCursorRot;
    private Quaternion firstLeftCursorRot;
    List<int> numbers = new List<int>();
    public List<int> Targetnumbers { get; set; } = new List<int>();
    public bool CanMoveBall { get; set; } = true;
    [SerializeField] GameObject whiteUi;
    [SerializeField] GameObject redUi;
    [SerializeField] float resttime = 6;
    [SerializeField] float RestwithNoUI = 4;
    private float nowresttime = 0;
    private bool isResting = false;
    [SerializeField] TextMeshProUGUI _MinDistanceUI;


    // Start is called before the first frame update
    void Start()
    {
        textforEnd.SetActive(false);
        whiteUi.SetActive(false);
        redUi.SetActive(false);
        RopeInitialize();
        Initialize();
        _MinDistanceUI.text = "";
        for (int i = 0; i < TargetList.TargetsList[0].Count; i++)
        {
            numbers.Add(i);
        }

        while (numbers.Count > 0)
        {

            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];
            Targetnumbers.Add(ransu);
            numbers.RemoveAt(index);
        }
        _cursorRigidbody = Cursor.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTracing)
        {
            isResting = true;
            ResetPos();
            UpdateParameter();
            whiteUi.SetActive(true);
            redUi.SetActive(true);
            CanMoveBall = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            isResting = true;
            _MinDistanceUI.text = "";
        }
        if (Cursor.position.y < -10) ResetPos();

    }
    void FixedUpdate()
    {
        if (isResting && !isFinished)
        {
            nowresttime += Time.fixedDeltaTime;
            if (nowresttime < RestwithNoUI)
            {

            }
            else if (nowresttime >= RestwithNoUI && nowresttime <= resttime)
            {
                whiteUi.SetActive(false);
                _MinDistanceUI.text = "";
            }
            else if (nowresttime  > resttime)
            {
                redUi.SetActive(false);
                isTracing = true;
                isResting = false;
                nowresttime = 0;
            }
        }


        if (isTracing)
        {
            TrialTime += Time.fixedDeltaTime;
            if (TrialTime > ReadyTime && TrialTime <= timelimit && !isFinished)
            {
                if (!CanMoveBall)                    
                {
                    CanMoveBall = true;
                    _TargetManager.EnableTarget();
                    _ObstacleManager.EnableObstacle();
                }
                InputRecord();
            }
            else if (TrialTime > timelimit)
            {
                OneTrialFinish();
                if (nowTrial == numTrial)
                {
                    isFinished = true;
                    textforEnd.SetActive(true);
                    _inputRecorder.WritingToServer();
                    _ResultRecorder.WritingToServer();
                }
                else
                {
                    nowTrial += 1;
                    ResetPos();
                    UpdateParameter();
                }
            }
        }
    }

    private void OneTrialFinish()
    {
        result.Add(_TargetManager.CalculateScore());
        isTracing = false;
        //isResting = true;
        CanMoveBall = false;
        whiteUi.SetActive(true);
        redUi.SetActive(true);
        UpdateUI();
        TrialTime = 0;
    }

    private void UpdateParameter()
    {
        _TargetManager.SetTarget(Targetnumbers[nowTrial - 1]);
        _ObstacleManager.SetObstacle(Targetnumbers[nowTrial - 1]);
        Debug.Log((Targetnumbers[nowTrial - 1]+1).ToString());
        _TargetManager.DisableTarget();
        _ObstacleManager.DisableObstacle();
    }


    void InputRecord()
    {
        _inputRecorder.TrialList.Add(nowTrial);
        _inputRecorder.RestTimeList.Add(TrialTime-ReadyTime);
        _inputRecorder.LeftInputList.Add(Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0));
        _inputRecorder.RightInputList.Add(Input.GetKey(KeyCode.UpArrow) ? 1 : (Input.GetKey(KeyCode.DownArrow) ? -1 : 0));
        _inputRecorder.LeftPosList.Add(LeftCursor.transform.position);
        _inputRecorder.RightPosList.Add(RightCursor.transform.position);
        _inputRecorder.TargetPosList.Add(Cursor.transform.position);
        _inputRecorder.NumList.Add(Targetnumbers[nowTrial-1]);
    }

    void UpdateUI()
    {
        _MinDistanceUI.text = result[nowTrial-1].ToString("f4") + "\n" + "Press P button to proceed";
    }

    void RopeInitialize()
    {
        foreach (Transform child in RopeParent.transform)
        {
            RopeChildrenTransform.Add(child);
            Vector3 pos = child.position;
            Quaternion rot = child.rotation;
            RopeChildrenfirstPosition.Add(pos);
            RopeChildrenfirstQuaternion.Add(rot);
        }
    }
    private void Initialize()
    {
        firstCursorPos = Cursor.transform.position;
        firstCursorRot = Cursor.transform.rotation;
        firstRightCursorPos = RightCursor.transform.position;
        firstRightCursorRot = RightCursor.transform.rotation;
        firstLeftCursorPos = LeftCursor.transform.position;
        firstLeftCursorRot = LeftCursor.transform.rotation;
    }
    private void ResetPos()
    {
        Cursor.transform.position = firstCursorPos;
        Cursor.transform.rotation = firstCursorRot;
        RightCursor.transform.position = firstRightCursorPos;
        RightCursor.transform.rotation = firstRightCursorRot;
        LeftCursor.transform.position = firstLeftCursorPos;
        LeftCursor.transform.rotation = firstLeftCursorRot;
        for (int i = 0; i < RopeChildrenTransform.Count; i++)
        {
            RopeChildrenTransform[i].position = RopeChildrenfirstPosition[i];
            RopeChildrenTransform[i].rotation = RopeChildrenfirstQuaternion[i];
        }
        _cursorRigidbody.velocity = new Vector2(0, 0);
    }
}
