using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float DamageMultiplier = 0.1f;

    public void SetDamage(int value)
    {
        Damage += value * DamageMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.gameObject.Equals(this))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }

    }
}
