using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int damage = 20;
    public GameObject impactEffect;
    public GameObject Me;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            if (player.health <= 0)
            {
                Me.gameObject.SetActive(true);
            }
        }

    }

}
