using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
