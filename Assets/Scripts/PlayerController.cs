using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float _speed = 4;

    [SerializeField]
    private float _jumpForce = 4;

    [SerializeField]
    private Transform _checkGround;

    [SerializeField]
    private LayerMask _layerGround;

    [SerializeField]
    private GameObject _attackObject;

    [SerializeField]
    private float _attackOffset = 4f;

    private Rigidbody2D _rb;

    private SpriteRenderer _sp;

    private Animator _animator;

    private float _directionX = 1;
    private bool Crouching;
    private float CrouchTime;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        bool isGround = Physics2D.OverlapCircle(_checkGround.position, .2f, _layerGround);

        _rb.velocity = new Vector2(_speed * move, _rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
            if (isGround)
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);

        if (move != 0 && move != _directionX) 
            Flip();        

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Vector2 portalPosition = transform.localPosition + new Vector3(_attackOffset * _directionX, 0, 0);
            Instantiate(_attackObject, portalPosition, Quaternion.Euler(Vector3.zero));
        }
        Crouch();//просто для мемов, но надо стейт машину мб

        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Crouching)
            {
                Crouching = true;
                CrouchTime = 1.25f;
                Vector3 ScaleChange = new Vector3(1, 0.5f, 1);
                transform.localScale = Vector3.Scale(transform.localScale, ScaleChange);
            }
        }
        CrouchTime -= Time.deltaTime;
        if (CrouchTime < 0) {
            if(Crouching)
            {
                Vector3 ScaleChange = new Vector3(1, 2, 1);
                transform.localScale = Vector3.Scale(transform.localScale, ScaleChange);
                Crouching = false;
            }
        }
    }

    private void Flip()
    {        
        _directionX = -_directionX;
        transform.localScale = new Vector3(_directionX, transform.localScale.y, transform.localScale.z);
    }
}