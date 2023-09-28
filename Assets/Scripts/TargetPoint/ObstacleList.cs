using System.Collections.Generic;
using UnityEngine;



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

    public static List<Vector3> upperleft = new List<Vector3>
    {
        new Vector3(-2.5f,1.5f,0.5f),
        new Vector3(-3.5f,3.5f,0.5f),
        new Vector3(-1.5f,2.5f,0.5f),
        new Vector3(-3.1f,1.1f,0.5f),
        new Vector3(-3.5f,2.0f,0.5f),
        new Vector3(-3.1f,1.5f,0.5f),
        new Vector3(-2.8f,1.5f,0.5f),
        new Vector3(-1.5f,2.1f,0.5f),
        new Vector3(-1.9f,2.5f,0.5f),
        new Vector3(-3.5f,1.5f,0.5f),
    };
    public static List<Vector3> upperright = new List<Vector3>
    {
        new Vector3(3.5f,2.5f,0.5f),
        new Vector3(3.5f,2.5f,0.5f),
        new Vector3(3.5f,2.0f,0.5f),
        new Vector3(2.5f,3.1f,0.5f),
        new Vector3(3.3f,1.6f,0.5f),
        new Vector3(4.1f,1.1f,0.5f),
        new Vector3(3.4f,3.1f,0.5f),
        new Vector3(1.4f,1.6f,0.5f),
        new Vector3(2.2f,3.9f,0.5f),
        new Vector3(1.9f,2.5f,0.5f),
    };
    public static List<Vector3> lowerleft = new List<Vector3>
    {
        new Vector3(-2.5f,-2.5f,0.5f),
        new Vector3(-4.5f,-3.0f,0.5f),
        new Vector3(-2.5f,-2.5f,0.5f),
        new Vector3(-2.3f,-2.5f,0.5f),
        new Vector3(-2.1f,-3.5f,0.5f),
        new Vector3(-3.0f,-2.5f,0.5f),
        new Vector3(-2.3f,-3.5f,0.5f),
        new Vector3(-3.1f,-3.5f,0.5f),
        new Vector3(-3.5f,-2.5f,0.5f),
        new Vector3(-3.5f,-3.5f,0.5f),
    };
    public static List<Vector3> lowerright = new List<Vector3>
    {
        new Vector3(3.5f,-2.5f,0.5f),
        new Vector3(2.5f,-2.5f,0.5f),
        new Vector3(1.5f,-3.5f,0.5f),
        new Vector3(3.1f,-3.5f,0.5f),
        new Vector3(2.1f,-3.2f,0.5f),
        new Vector3(3.1f,-2.4f,0.5f),
        new Vector3(2.6f,-1.8f,0.5f),
        new Vector3(3.1f,-3.5f,0.5f),
        new Vector3(4.2f,-3.5f,0.5f),
        new Vector3(1.9f,-2.5f,0.5f),
    };
    public static List<Vector3> upperleftSize = new List<Vector3>
    {
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(2.0f,2.5f,0.5f),
        new Vector3(0.5f,3.5f,0.5f),
        new Vector3(1.5f,2.5f,0.5f),
        new Vector3(0.5f,3.5f,0.5f),
        new Vector3(2.0f,2.5f,0.5f),
        new Vector3(6.5f,0.5f,0.5f),
        new Vector3(0.5f,1.5f,0.5f),
        new Vector3(0.5f,3.5f,0.5f),
        new Vector3(0.5f,4.5f,0.5f),
    };
    public static List<Vector3> upperrightSize = new List<Vector3>
    {
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(1.5f,1.5f,0.5f),
        new Vector3(0.5f,0.5f,0.5f),
        new Vector3(2.5f,0.5f,0.5f),
        new Vector3(0.5f,0.5f,0.5f),
        new Vector3(2.5f,1.0f,0.5f),
        new Vector3(0.5f,3.5f,0.5f),
        new Vector3(2.5f,2.5f,0.5f),
        new Vector3(0.5f,2.5f,0.5f),
        new Vector3(0.5f,4.5f,0.5f),
    };
    public static List<Vector3> lowerleftSize = new List<Vector3>
    {
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(0.5f,2.5f,0.5f),
        new Vector3(4.5f,0.5f,0.5f),
        new Vector3(3.5f,0.5f,0.5f),
        new Vector3(2.0f,0.5f,0.5f),
        new Vector3(3.5f,0.5f,0.5f),
        new Vector3(1.5f,3.5f,0.5f),
        new Vector3(0.5f,0.5f,0.5f),
        new Vector3(1.5f,0.5f,0.5f),
        new Vector3(1.5f,0.5f,0.5f),
    };
    public static List<Vector3> lowerrightSize = new List<Vector3>
    {
        new Vector3(2.0f,2.0f,0.5f),
        new Vector3(2.5f,2.5f,0.5f),
        new Vector3(2.5f,2.5f,0.5f),
        new Vector3(1.0f,1.0f,0.5f),
        new Vector3(1.5f,2.5f,0.5f),
        new Vector3(3.5f,0.5f,0.5f),
        new Vector3(2.5f,2.5f,0.5f),
        new Vector3(0.5f,2.0f,0.5f),
        new Vector3(0.5f,2.5f,0.5f),
        new Vector3(2.5f,1.5f,0.5f),
    };

    public static List<Quaternion> upperleftRot = new List<Quaternion>
    {
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f))
    };
    public static List<Quaternion> upperrightRot = new List<Quaternion>
    {
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,15f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f))
    };
    public static List<Quaternion> lowerleftRot = new List<Quaternion>
    {
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-15f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-15f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f))
    };
    public static List<Quaternion> lowerrightRot = new List<Quaternion>
    {
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f)),
        Quaternion.Euler(new Vector3(0f,0f,-1f)),
        Quaternion.Euler(new Vector3(0f,0f,1f))
    };
}
