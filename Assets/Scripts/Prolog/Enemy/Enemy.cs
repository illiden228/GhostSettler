using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
