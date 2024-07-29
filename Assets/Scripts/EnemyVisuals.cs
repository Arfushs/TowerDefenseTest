using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _upSprite;
    [SerializeField] private Sprite _downSprite;
    [SerializeField] private Sprite _rightSprite;

    private Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        SetupVisual();
    }

    void SetupVisual()
    {
        Vector2 direction = _enemy.GetDirection();

        if (direction == Vector2.left)
        {
            _spriteRenderer.flipX = true;
            _spriteRenderer.sprite = _rightSprite;
        }
        else if (direction == Vector2.right)
        {
            _spriteRenderer.flipX = false;
            _spriteRenderer.sprite = _rightSprite;
        }
        else if (direction == Vector2.up)
        {
            _spriteRenderer.sprite = _upSprite;
        }
        else if (direction == Vector2.down)
        {
            _spriteRenderer.sprite = _downSprite;
        }
    }
}
