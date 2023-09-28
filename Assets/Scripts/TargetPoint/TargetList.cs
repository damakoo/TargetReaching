using System.Collections.Generic;
using UnityEngine;

public static class TargetList
{
    static TargetList()
    {
        TargetsList = new List<List<Vector3>>
        {
            upperleft,
            upperright,
            lowerleft,
            lowerright
        };

    }

    public static List<List<Vector3>> TargetsList;

    public static List<Vector3> upperleft = new List<Vector3>
    {
        new Vector3(-4,2,1),
        new Vector3(-5,3,1),
        new Vector3(-6,2,1),
        new Vector3(-4.5f,2,1),
        new Vector3(-5.5f,2.3f,1),
        new Vector3(-6.2f,2.5f,1),
        new Vector3(-3,3,1),
        new Vector3(-6,1.2f,1),
        new Vector3(-5,2,1),
        new Vector3(-4,2,1),
    };
    public static List<Vector3> upperright = new List<Vector3>
    {
        new Vector3(5,1.7f,1),
        new Vector3(6,2,1),
        new Vector3(4,3.2f,1),
        new Vector3(4.5f,2.5f,1),
        new Vector3(4.7f,2,1),
        new Vector3(3.2f,2.3f,1),
        new Vector3(5,2,1),
        new Vector3(4,2,1),
        new Vector3(5,1.6f,1),
        new Vector3(6,2.5f,1),
    };
    public static List<Vector3> lowerleft = new List<Vector3>
    {
        new Vector3(-4.5f,-4,1),
        new Vector3(-6.1f,-3,1),
        new Vector3(-5.2f,-4f,1),
        new Vector3(-4,-4.2f,1),
        new Vector3(-3,-4.5f,1),
        new Vector3(-5.3f,-4f,1),
        new Vector3(-4.3f,-4.3f,1),
        new Vector3(-4,-3.6f,1),
        new Vector3(-5.6f,-3.3f,1),
        new Vector3(-3,-4.8f,1),
    };
    public static List<Vector3> lowerright = new List<Vector3>
    {
        new Vector3(4.3f,-4f,1),
        new Vector3(4.3f,-3.5f,1),
        new Vector3(4.5f,-4.2f,1),
        new Vector3(6.2f,-4.1f,1),
        new Vector3(4f,-3.0f,1),
        new Vector3(6.3f,-4.1f,1),
        new Vector3(5,-3.1f,1),
        new Vector3(4.2f,-4.2f,1),
        new Vector3(5.6f,-3f,1),
        new Vector3(5.8f,-3.8f,1),
    };
}
