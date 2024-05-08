using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float lifetime;

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
            Destroy(gameObject);
    }
    //�������� ����� - ���� ��������� ��� ����� ����� � �� ����� ����� ������� �� ������������� ������� �� ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable hit = collision.GetComponent<Enemy>();
        if (hit != null)
            hit.OnEnterAttackArea();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamagable hit = collision.GetComponent<Enemy>();

        if (hit != null)
            hit.OnExitAttackArea();
    }
}
