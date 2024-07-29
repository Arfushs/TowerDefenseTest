using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private int _weight;
    [SerializeField] private float _moveSpeed = 5f;
    
    private List<Transform> _waypoints;
    private int _currentWaypointIndex = 0;
    private float _currentHP;

    public void InitializeEnemy(List<Transform> Waypoints)
    {
        _waypoints = Waypoints;
        _currentHP = _maxHP;
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
            
            _currentWaypointIndex++;
        }
        
    }

    public void DestroySelf()
    {
        StopCoroutine(MoveAlongWaypoints());
        Destroy(gameObject);
    }

    public Vector2 GetDirection()
    {
        if (_currentWaypointIndex >= _waypoints.Count)
        {
            return Vector2.zero;
        }

        Transform currentWaypoint = _waypoints[_currentWaypointIndex];
        Vector2 direction = (currentWaypoint.position - transform.position).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return direction.x > 0 ? Vector2.right : Vector2.left;
        }
        else
        {
            return direction.y > 0 ? Vector2.up : Vector2.down;
        }
    }

    public void TakeDamage(float amount)
    {
        _currentHP -= amount;
        if (_currentHP <= 0)
            Destroy(gameObject);
    }
    public int Weight() => _weight;


}
