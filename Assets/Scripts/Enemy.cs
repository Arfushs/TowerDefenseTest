using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO _enemyConfig;
    [SerializeField] private float _moveSpeed = 5f;
    private List<Transform> _waypoints;

    public void InitializeEnemy(List<Transform> Waypoints)
    {
        _waypoints = Waypoints;
        StartCoroutine(MoveAlongWaypoints());
    }

    IEnumerator MoveAlongWaypoints()
    {
        foreach (Transform waypoint in _waypoints)
        {
            
            Vector3 targetPosition = waypoint.position;
            
            float distance = Vector3.Distance(transform.position, targetPosition);
            
            float duration = distance / _moveSpeed;
            
            yield return transform.DOMove(targetPosition, duration).SetEase(Ease.Linear).WaitForCompletion();
        }
        
        
    }
}
