using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatePracticeSet : MonoBehaviour
{
    [SerializeField] int NumberofSet = 1000;
    [SerializeField] Transform MinUR;
    [SerializeField] Transform MaxUR;
    [SerializeField] Transform MinUL;
    [SerializeField] Transform MaxUL;
    [SerializeField] Transform MinLR;
    [SerializeField] Transform MaxLR;
    [SerializeField] Transform MinLL;
    [SerializeField] Transform MaxLL;
    [SerializeField] string filename;


    [SerializeField] Vector2 MinURSize = new Vector2(0.5f, 0.5f);
    [SerializeField] Vector2 MaxURSize = new Vector2(3f, 3f);
    [SerializeField] Vector2 MinULSize = new Vector2(0.5f, 0.5f);
    [SerializeField] Vector2 MaxULSize = new Vector2(3f, 3f);
    [SerializeField] Vector2 MinLRSize = new Vector2(0.5f, 0.5f);
    [SerializeField] Vector2 MaxLRSize = new Vector2(3f, 3f);
    [SerializeField] Vector2 MinLLSize = new Vector2(0.5f, 0.5f);
    [SerializeField] Vector2 MaxLLSize = new Vector2(3f, 3f);

    Vector2 TargetUR;
    Vector2 TargetUL;
    Vector2 TargetLR;
    Vector2 TargetLL;
    Vector2 ObstacleUR;
    Vector2 ObstacleUL;
    Vector2 ObstacleLR;
    Vector2 ObstacleLL;
    Vector2 ObstacleSizeUR;
    Vector2 ObstacleSizeUL;
    Vector2 ObstacleSizeLR;
    Vector2 ObstacleSizeLL;

    private string PracticeSet;

    // Start is called before the first frame update
    void Start()
    {
        PracticeSet = "TargetUR_x,TargetUR_y,TargetUL_x,TargetUL_y,TargetLR_x,TargetLR_y,TargetLL_x,TargetLL_y,";
        PracticeSet += "ObstacleUR_x,ObstacleUR_y,ObstacleUL_x,ObstacleUL_y,ObstacleLR_x,ObstacleLR_y,ObstacleLL_x,ObstacleLL_y,";
        PracticeSet += "ObstacleSizeUR_x,ObstacleSizeUR_y,ObstacleSizeUL_x,ObstacleSizeUL_y,ObstacleSizeLR_x,ObstacleSizeLR_y,ObstacleSizeLL_x,ObstacleSizeLL_y";

        WriteCSV(PracticeSet);

        for(int i = 0;i < NumberofSet; i++)
        {
            PracticeSet = MakePracticeSet();
            WriteCSV(PracticeSet);
        }
    }
    private string MakePracticeSet()
    {
        MakeTargetObstacleSet();
        return TargetUR.x.ToString() + "," + TargetUR.y.ToString() + "," + TargetUL.x.ToString() + "," + TargetUL.y.ToString() + "," + TargetLR.x.ToString() + "," + TargetLR.y.ToString() + "," + TargetLL.x.ToString() + "," + TargetLL.y.ToString()
            + "," + ObstacleUR.x.ToString() + "," + ObstacleUR.y.ToString() + "," + ObstacleUL.x.ToString() + "," + ObstacleUL.y.ToString() + "," + ObstacleLR.x.ToString() + "," + ObstacleLR.y.ToString() + "," + ObstacleLL.x.ToString() + "," + ObstacleLL.y.ToString()
            + "," + ObstacleSizeUR.x.ToString() + "," + ObstacleSizeUR.y.ToString() + "," + ObstacleSizeUL.x.ToString() + "," + ObstacleSizeUL.y.ToString() + "," + ObstacleSizeLR.x.ToString() + "," + ObstacleSizeLR.y.ToString() + "," + ObstacleSizeLL.x.ToString() + "," + ObstacleSizeLL.y.ToString();
    }


    private void MakeTargetObstacleSet()
    {

        TargetUR = new Vector2(Random.Range(MinUR.position.x, MaxUR.position.x), Random.Range(MinUR.position.y, MaxUR.position.y));
        ObstacleUR = new Vector2(Random.Range(MinUR.position.x, MaxUR.position.x), Random.Range(MinUR.position.y, MaxUR.position.y));
        ObstacleSizeUR = new Vector2(Random.Range(MinURSize.x, MaxURSize.x), Random.Range(MinURSize.y, MaxURSize.y));
        while (JudgeConflict(TargetUR, ObstacleUR, ObstacleSizeUR, MinUR.position, MaxUR.position))
        {
            TargetUR = new Vector2(Random.Range(MinUR.position.x, MaxUR.position.x), Random.Range(MinUR.position.y, MaxUR.position.y));
            ObstacleUR = new Vector2(Random.Range(MinUR.position.x, MaxUR.position.x), Random.Range(MinUR.position.y, MaxUR.position.y));
            ObstacleSizeUR = new Vector2(Random.Range(MinURSize.x, MaxURSize.x), Random.Range(MinURSize.y, MaxURSize.y));
        }


        TargetUL = new Vector2(Random.Range(MinUL.position.x, MaxUL.position.x), Random.Range(MinUL.position.y, MaxUL.position.y));
        ObstacleUL = new Vector2(Random.Range(MinUL.position.x, MaxUL.position.x), Random.Range(MinUL.position.y, MaxUL.position.y));
        ObstacleSizeUL = new Vector2(Random.Range(MinULSize.x, MaxULSize.x), Random.Range(MinULSize.y, MaxULSize.y));
        while (JudgeConflict(TargetUL, ObstacleUL, ObstacleSizeUL, MinUL.position, MaxUL.position))
        {
            TargetUL = new Vector2(Random.Range(MinUL.position.x, MaxUL.position.x), Random.Range(MinUL.position.y, MaxUL.position.y));
            ObstacleUL = new Vector2(Random.Range(MinUL.position.x, MaxUL.position.x), Random.Range(MinUL.position.y, MaxUL.position.y));
            ObstacleSizeUL = new Vector2(Random.Range(MinULSize.x, MaxULSize.x), Random.Range(MinULSize.y, MaxULSize.y));
        }

        TargetLR = new Vector2(Random.Range(MinLR.position.x, MaxLR.position.x), Random.Range(MinLR.position.y, MaxLR.position.y));
        ObstacleLR = new Vector2(Random.Range(MinLR.position.x, MaxLR.position.x), Random.Range(MinLR.position.y, MaxLR.position.y));
        ObstacleSizeLR = new Vector2(Random.Range(MinLRSize.x, MaxLRSize.x), Random.Range(MinLRSize.y, MaxLRSize.y));
        while (JudgeConflict(TargetLR, ObstacleLR, ObstacleSizeLR, MinLR.position, MaxLR.position))
        {
            TargetLR = new Vector2(Random.Range(MinLR.position.x, MaxLR.position.x), Random.Range(MinLR.position.y, MaxLR.position.y));
            ObstacleLR = new Vector2(Random.Range(MinLR.position.x, MaxLR.position.x), Random.Range(MinLR.position.y, MaxLR.position.y));
            ObstacleSizeLR = new Vector2(Random.Range(MinLRSize.x, MaxLRSize.x), Random.Range(MinLRSize.y, MaxLRSize.y));
        }

        TargetLL = new Vector2(Random.Range(MinLL.position.x, MaxLL.position.x), Random.Range(MinLL.position.y, MaxLL.position.y));
        ObstacleLL = new Vector2(Random.Range(MinLL.position.x, MaxLL.position.x), Random.Range(MinLL.position.y, MaxLL.position.y));
        ObstacleSizeLL = new Vector2(Random.Range(MinLLSize.x, MaxLLSize.x), Random.Range(MinLLSize.y, MaxLLSize.y));
        while (JudgeConflict(TargetLL, ObstacleLL, ObstacleSizeLL, MinLL.position, MaxLL.position))
        {
            TargetLL = new Vector2(Random.Range(MinLL.position.x, MaxLL.position.x), Random.Range(MinLL.position.y, MaxLL.position.y));
            ObstacleLL = new Vector2(Random.Range(MinLL.position.x, MaxLL.position.x), Random.Range(MinLL.position.y, MaxLL.position.y));
            ObstacleSizeLL = new Vector2(Random.Range(MinLLSize.x, MaxLLSize.x), Random.Range(MinLLSize.y, MaxLLSize.y));
        }
    }
    private bool JudgeConflict(Vector2 _target, Vector2 _obstacle, Vector2 _obstaclesize, Vector2 _min, Vector2 _max)
    {
        bool Result = false;
        if (Mathf.Abs(_target.x) < Mathf.Abs(_obstacle.x) || Mathf.Abs(_target.y) < Mathf.Abs(_obstacle.y)) Result = true;
        if (Mathf.Abs(_target.x - _obstacle.x) < _obstaclesize.x / 2 + 0.5f && (Mathf.Abs(_target.y - _obstacle.y) < _obstaclesize.y / 2 + 0.5f)) Result = true;
        if (Mathf.Abs(_obstacle.x - _min.x) < _obstaclesize.x / 2) Result = true;
        if (Mathf.Abs(_obstacle.y - _min.y) < _obstaclesize.y / 2) Result = true;
        return Result;
    }

    private void WriteCSV(string line)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/StreamingAssets/Set_Practice/" + filename + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(line);
        streamWriter.Flush();
        streamWriter.Close();
    }

}
