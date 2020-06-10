using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    public int health = 100;

    float moveSpeed = 5f;
    float bulletForce = 2f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 direction;

    public Transform player;
    public Transform Gun;

    public GameObject deatEffect;
    public GameObject laserPrefab;

    public Transform firePoint;

    public IEnumerator Shoot()
    {
        for(int i = 0; i < 1000000; i++)
        {
            GameObject bullet = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(2);
        }
    }

    public void Start()
    {
            StartCoroutine(Shoot());
    }

    private void FixedUpdate()
    {
        /*rb.MoveRotation(rb.rotation * moveSpeed * Time.deltaTime);

        Vector2 lookDir = player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;*/

        Vector2 playerPos = (Vector2)player.position;
        direction = playerPos - (Vector2)Gun.position;
        FaceGun();
    }

    void FaceGun()
    {
        Gun.transform.right = direction;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deatEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
