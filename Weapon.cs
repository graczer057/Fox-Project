using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bowHidden;
    public GameObject bowShoot;
    public Bow bow;

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            bowHidden.gameObject.SetActive(false);
            bowShoot.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.K))
            {
                Shoot();
            }
            else
            {
                bow.GetComponent<Bow>().Neg();
            }
        }
        else
        {
            bowHidden.gameObject.SetActive(true);
            bowShoot.gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bow.GetComponent<Bow>().Pos();
    }
}
