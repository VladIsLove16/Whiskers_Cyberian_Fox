using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    private Transform _left;

    [SerializeField]
    private Transform _right;

    [SerializeField]
    private float _speed = 0;

    [SerializeField]
    private float _slowSpeed = 0;

    private float _currentSpeed = 0;

    private SpriteRenderer _renderer;

    private Rigidbody2D _rb;

    private float _move = 1;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _left.parent = null;
        _right.parent = null;

        _currentSpeed = _speed;
    }

    void Update()
    {
        _rb.velocity = new Vector2(_move * _currentSpeed, _rb.velocity.y);

        if (transform.position.x > _right.position.x)
        {
            _move = -1;
            _renderer.flipX = true;
        }
        else if (transform.position.x < _left.position.x)
        {
            _move = 1;
            _renderer.flipX = false;
        }
    }

    public void OnEnterAttackArea()
    {
        _currentSpeed = _slowSpeed;
    }

    public void OnExitAttackArea()
    {
        _currentSpeed = _speed;
    }
}
