using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public static event Action OnBaseDeath; 
    
    [SerializeField] private int MAX_HEALTH_POINT;
    private int _currentHP;

    private void Awake()
    {
        _currentHP = MAX_HEALTH_POINT;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Enemy e = other.GetComponent<Enemy>();
            _currentHP-=e.Weight();
            e.DestroySelf();
            Debug.Log("Current Base Health: " + _currentHP);
        }
            
    }
}
