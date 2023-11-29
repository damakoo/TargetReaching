using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class ObstacleList
{
    static ObstacleList()
    {
        ObstaclesPosList = new List<List<Vector3>>
        {
            upperleft,
            upperright,
            lowerleft,
            lowerright
        };
        ObstaclesSizeList = new List<List<Vector3>>
        {
            upperleftSize,
            upperrightSize,
            lowerleftSize,
            lowerrightSize
        };
        ObstaclesRotList = new List<List<Quaternion>>
        {
            upperleftRot,
            upperrightRot,
            lowerleftRot,
            lowerrightRot
        };

    }

    public static List<List<Vector3>> ObstaclesPosList;
    public static List<List<Vector3>> ObstaclesSizeList;
    public static List<List<Quaternion>> ObstaclesRotList;


    public static void UpdateParameter(List<int> Practice_set, string _filepath)
    {

        // CSVファイルを全ての行で読み込む
        string[] lines = File.ReadAllLines(_filepath);

        for (int i = 0; i < Practice_set.Count; i++)
        {
            int Practicenum = Practice_set[i];
            // 行をカンマで分割して列のデータを取得
            string[] columns = lines[Practicenum].Split(',');

            // 列のインデックスを見つける
            string[] headers = lines[0].Split(',');

            // Posの値を取得して追加
            upperleft.Add(new Vector2(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleUL_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleUL_y")])));
            upperright.Add(new Vector2(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleUR_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleUR_y")])));
            lowerleft.Add(new Vector2(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleLL_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleLL_y")])));
            lowerright.Add(new Vector2(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleLR_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleLR_y")])));
            upperleftSize.Add(new Vector3(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeUL_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeUL_y")]), 1));
            upperrightSize.Add(new Vector3(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeUR_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeUR_y")]), 1));
            lowerleftSize.Add(new Vector3(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeLL_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeLL_y")]), 1));
            lowerrightSize.Add(new Vector3(float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeLR_x")]), float.Parse(columns[System.Array.IndexOf(headers, "ObstacleSizeLR_y")]), 1));
            upperleftRot.Add(Quaternion.identity);
            upperrightRot.Add(Quaternion.identity);
            lowerleftRot.Add(Quaternion.identity);
            lowerrightRot.Add(Quaternion.identity);

        }
    }

    public static List<Vector3> upperleft = new List<Vector3>
    {
        /*
        new Vector3(-2.5f,1.5f,0.5f),
        new Vector3(-3.5f,3.5f,0.5f),
        new Vector3(-1.5f,2.5f,0.5f),
        new Vector3(-3.1f,3.0f,0.5f),
        new Vector3(-3.5f,2.0f,0.5f),
        new Vector3(-3.1f,2.7f,0.5f),
        new Vector3(-4.8f,1.5f,0.5f),
        new Vector3(-3.5f,2.1f,0.5f),
        new Vector3(-3.0f,2.5f,0.5f),
        new Vector3(-3.5f,3.5f,0.5f),
        */
    };
    public static List<Vector3> upperright = new List<Vector3>
    {
        /*
        new Vector3(3.5f,2.5f,0.5f),
        new Vector3(3.5f,2.5f,0.5f),
        new Vector3(3.5f,2.0f,0.5f),
        new Vector3(2.5f,3.5f,0.5f),
        new Vector3(3.3f,1.6f,0.5f),
        new Vector3(4.1f,1.1f,0.5f),
        new Vector3(3.4f,3.1f,0.5f),
        new Vector3(1.4f,3.0f,0.5f),
        new Vector3(2.2f,2.6f,0.5f),
        new Vector3(1.9f,2.5f,0.5f),
        */
    };
    public static List<Vector3> lowerleft = new List<Vector3>
    {
        /*
        new Vector3(-2.5f,-2.5f,0.5f),
        new Vector3(-3.5f,-1.6f,0.5f),
        new Vector3(-2.5f,-3.0f,0.5f),
        new Vector3(-1.0f,-4.0f,0.5f),
        new Vector3(-2.7f,-3.5f,0.5f),
        new Vector3(-3.0f,-2.5f,0.5f),
        new Vector3(-2.3f,-3.5f,0.5f),
        new Vector3(-3.1f,-3.5f,0.5f),
        new Vector3(-2.8f,-2.5f,0.5f),
        new Vector3(-3.5f,-3.5f,0.5f),
        */
    };
    public static List<Vector3> lowerright = new List<Vector3>
    {
        /*
        new Vector3(4.5f,-2.5f,0.5f),
        new Vector3(2.5f,-1.5f,0.5f),
        new Vector3(2.0f,-4.0f,0.5f),
        new Vector3(3.1f,-3.5f,0.5f),
        new Vector3(2.1f,-3.2f,0.5f),
        new Vector3(3.1f,-2.4f,0.5f),
        new Vector3(2.6f,-1.8f,0.5f),
        new Vector3(3.1f,-3.5f,0.5f),
        new Vector3(4.2f,-3.85f,0.5f),
        new Vector3(1.9f,-2.5f,0.5f),
        */
    };
    public static List<Vector3> upperleftSize = new List<Vector3>
    {
        /*
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(0.2f,2.5f,0.5f),
        new Vector3(0.5f,3.5f,0.5f),
        new Vector3(1.0f,2.5f,0.5f),
        new Vector3(0.5f,3.5f,0.5f),
        new Vector3(2.0f,2.5f,0.5f),
        new Vector3(6.5f,0.5f,0.5f),
        new Vector3(0.5f,1.5f,0.5f),
        new Vector3(0.5f,2.5f,0.5f),
        new Vector3(0.5f,4.5f,0.5f),
        */
    };
    public static List<Vector3> upperrightSize = new List<Vector3>
    {
        /*
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(1.5f,1.5f,0.5f),
        new Vector3(0.5f,0.5f,0.5f),
        new Vector3(1.5f,3.5f,0.5f),
        new Vector3(0.5f,0.5f,0.5f),
        new Vector3(2.5f,1.0f,0.5f),
        new Vector3(0.5f,3.5f,0.5f),
        new Vector3(2.5f,2.5f,0.5f),
        new Vector3(3.5f,2.5f,0.5f),
        new Vector3(0.5f,4.5f,0.5f),
        */
    };
    public static List<Vector3> lowerleftSize = new List<Vector3>
    {
        /*
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(0.5f,1.2f,0.5f),
        new Vector3(4.0f,0.5f,0.5f),
        new Vector3(3.5f,0.5f,0.5f),
        new Vector3(2.0f,0.5f,0.5f),
        new Vector3(3.0f,0.5f,0.5f),
        new Vector3(1.5f,3.5f,0.5f),
        new Vector3(0.5f,1.5f,0.5f),
        new Vector3(1.5f,0.5f,0.5f),
        new Vector3(1.5f,0.5f,0.5f),
        */
    };
    public static List<Vector3> lowerrightSize = new List<Vector3>
    {
        /*
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(2.5f,0.5f,0.5f),
        new Vector3(3.0f,2.0f,0.5f),
        new Vector3(1.0f,1.0f,0.5f),
        new Vector3(1.5f,2.5f,0.5f),
        new Vector3(3.0f,0.5f,0.5f),
        new Vector3(2.5f,1.0f,0.5f),
        new Vector3(0.5f,2.0f,0.5f),
        new Vector3(0.5f,2.5f,0.5f),
        new Vector3(2.5f,1.5f,0.5f),
        */
    };

    public static List<Quaternion> upperleftRot = new List<Quaternion>
    {
        /*
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,20f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,30f)),
        Quaternion.Euler(new Vector3(0f,0f,40f))
        */
    };
    public static List<Quaternion> upperrightRot = new List<Quaternion>
    {
        /*
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,-40f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,15f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f))
        */
    };
    public static List<Quaternion> lowerleftRot = new List<Quaternion>
    {
        /*
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,20f)),
        Quaternion.Euler(new Vector3(0f,0f,-15f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-15f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f))
        */
    };
    public static List<Quaternion> lowerrightRot = new List<Quaternion>
    {
        /*
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-10f)),
        Quaternion.Euler(new Vector3(0f,0f,1f))
        */
    };
}
