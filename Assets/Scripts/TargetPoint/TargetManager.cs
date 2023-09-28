using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<GameObject> _TargetList = new List<GameObject>();
    [SerializeField] GameObject TargetPrefab;
    [SerializeField] Transform Cursor;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        for(int i = 0; i < TargetList.TargetsList.Count;i++)
        {
            GameObject _target = Instantiate(TargetPrefab, Vector3.zero, Quaternion.identity, this.transform);
            _TargetList.Add(_target);
        }
        DisableTarget();
    }
    public void DisableTarget()
    {
        foreach (GameObject _target in _TargetList) _target.SetActive(false);
    }
    public void EnableTarget()
    {
        foreach (GameObject _target in _TargetList) _target.SetActive(true);
    }
    public void SetTarget(int posnum)
    {
        for (int i = 0; i < _TargetList.Count; i++)
        {
            _TargetList[i].transform.position = TargetList.TargetsList[i][posnum];
        }
    }
    public float CalculateScore()
    {
        float _score = 1000;
        foreach (GameObject _target in _TargetList)
        {
            float distance = ((Vector2)_target.transform.position - (Vector2)Cursor.position).magnitude;
            if (distance < _score) _score = distance;
        }
        return _score;
    }
}
