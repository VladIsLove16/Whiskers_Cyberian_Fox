using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour, IDamagable
{
    //бой
    public int MaxHP;
    public int CurrentHP;
    public float LightTimeGetDamage;
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

    //бой
    private float onLightTime;
    private bool onLight;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _left.parent = null;
        _right.parent = null;

        _currentSpeed = _speed;
        CurrentHP=MaxHP;
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
        LightMechanism();
      
    }

    private void LightMechanism()
    {
        if (onLight)
        {
            onLightTime += Time.deltaTime;
            if (onLightTime > LightTimeGetDamage)
            {
                CurrentHP--;
                onLightTime -= LightTimeGetDamage;
            }
        }
    }

    public void OnEnterAttackArea()
    {
        _currentSpeed = _slowSpeed;
        onLight=true;
    }

    public void OnExitAttackArea()
    {
        _currentSpeed = _speed;
        onLight=false;
    }
}
