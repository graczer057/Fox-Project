using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public GameObject deathEffect;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public void Start()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        for (int i = 0; i < 10000; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(1);
        }
    }
    
    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D headHit)
    {
        if (headHit.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

}
