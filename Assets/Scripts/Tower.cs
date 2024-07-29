using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePref;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private LayerMask _enemyLayer;

    private void Start()
    {
        StartTower();
    }

    public void StartTower()
    {
        StartCoroutine(Attack());
    }

    public void StopTower()
    {
        StopCoroutine(Attack());
    }
    

    private IEnumerator Attack()
    {
        while (true)
        {
            if (Physics2D.OverlapCircle(transform.position, _attackRange, _enemyLayer))
            {
                Projectile p = Instantiate(_projectilePref,transform.position,Quaternion.identity);
                p.SetupProjectile(_attackDamage,ChooseTarget());
            }

            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    private Transform ChooseTarget()
    {
        return Physics2D.OverlapCircle(transform.position, _attackRange, _enemyLayer).GetComponent<Transform>();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,_attackRange);
    }
}
