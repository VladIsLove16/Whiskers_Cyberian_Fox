using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Spawn;
    public AudioClip Living;
    public AudioClip Dead;

    [SerializeField]
    private float lifetime;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Close();
    }
    private async void Close()
    {
        audioSource.PlayOneShot(Dead);
        await Task.Delay(0);
        Destroy(gameObject);
    }

    //Огромный минус - если действуют две атаки сразу и из одной атаки выходит то автоматически выходит из второй
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
