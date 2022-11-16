using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.gameObject.Equals(this))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }

    }
}
