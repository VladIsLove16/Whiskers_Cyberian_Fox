using System.Collections;
using System.Collections.Generic;
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
    private Vector3 directionNormalized;
    private void Update()
    {
        transform.position += directionNormalized * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Attack attack = collision.gameObject.GetComponent<Attack>();
        if(attack != null)
        {
            Debug.Log("Пуля Испарилась");
            Destroy(gameObject);
        }
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.OnEnterAttackArea();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.OnExitAttackArea();
        }
    }
}
