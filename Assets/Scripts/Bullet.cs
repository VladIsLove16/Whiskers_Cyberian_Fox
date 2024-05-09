using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public Vector3 Direction
    {
        get { 
        return directionNormalized;
        }
        set
        {
            directionNormalized = value.normalized;
        }
    }
    [SerializeField]
    public Vector3 directionNormalized;
    private void FixedUpdate()
    {
        transform.position += directionNormalized * Speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Attack attack = other.gameObject.GetComponent<Attack>();
        if (attack != null)
        {
            Disappear();
        }
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.OnEnterAttackArea();
        }
    }
    private async void Disappear()
    {
        Debug.Log("Пуля попала в портал");
        Speed = 0;
        await Task.Delay(1000);
        Debug.Log("Пуля Испарилась");
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.OnExitAttackArea();
        }
    }
}
