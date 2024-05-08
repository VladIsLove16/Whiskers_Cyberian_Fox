using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    public int HP;
    public PlayerController Controller;
    [SerializeField]
    private float _speed = 0;
    [SerializeField]
    private float _slowSpeed = 0;
    private void Start()
    {
        Controller = GetComponent<PlayerController>();
    }
    public void OnEnterAttackArea()
    {
        Controller._speed = _slowSpeed;
        HP--;
    }
    public void OnExitAttackArea()
    {
        Controller._speed = _speed;
    }
}
