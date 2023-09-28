using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    List<GameObject> _ObstacleList = new List<GameObject>();
    [SerializeField] GameObject ObstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        for (int i = 0; i < ObstacleList.ObstaclesPosList.Count; i++)
        {
            GameObject _obstacle = Instantiate(ObstaclePrefab, Vector3.zero, Quaternion.identity, this.transform);
            _ObstacleList.Add(_obstacle);
        }
        DisableObstacle();
    }
    public void DisableObstacle()
    {
        foreach (GameObject _obstacle in _ObstacleList) _obstacle.SetActive(false);
    }
    public void EnableObstacle()
    {
        foreach (GameObject _obstacle in _ObstacleList) _obstacle.SetActive(true);
    }
    public void SetObstacle(int posnum)
    {

        for (int i = 0; i < _ObstacleList.Count; i++)
        {
            _ObstacleList[i].transform.position = ObstacleList.ObstaclesPosList[i][posnum];
            _ObstacleList[i].transform.localScale = ObstacleList.ObstaclesSizeList[i][posnum];
            _ObstacleList[i].transform.rotation = ObstacleList.ObstaclesRotList[i][posnum];
        }
    }
}
