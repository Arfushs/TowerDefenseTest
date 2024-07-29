using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _damage;
    [SerializeField] private float _moveSpeed;
    private Transform _target;

    public void SetupProjectile(float Damage,Transform Target)
    {
        _damage = Damage;
        _target = Target;
    }

    private void Update()
    {
        if (!_target)
            return;
        Vector3 dir = (_target.position - transform.position).normalized;
        transform.position += dir * (_moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
