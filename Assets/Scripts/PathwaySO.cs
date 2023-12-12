using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PathwaySO", menuName = "Wave Config")]
public class PathwaySO : ScriptableObject
{
    [SerializeField] Transform pathTrans;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] List<GameObject> enemies;

    public Transform GetStart() => pathTrans.GetChild(0);

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new();
        foreach(Transform child in pathTrans)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed() => moveSpeed;

    public int GetEnemyCount()
    {
        return enemies.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemies[index];
    }
}
