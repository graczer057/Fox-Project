using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
    public Slider healthSlider;
    public float speed = 60f;
    public int damage = 20;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public GameObject Me;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            if (player.health <= 0)
            {
                Me.gameObject.SetActive(true);
            }
            healthSlider.value -= damage;
        }


        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
