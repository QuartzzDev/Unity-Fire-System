// QuartzzDev

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FireController : MonoBehaviour
{
    [Header("Gerekliler - Qua Fire Controller")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    public AudioSource fireSource;
    public Animator gunAnimator;

    public float bulletSpeed = 10f;
    public float fireRate = 0.1f;

    private bool isFiring = false;

    void Update()
    {
        if (Input.GetButton("Fire1") && !isFiring)
        {
            isFiring = true;
            StartCoroutine(AutoFire());
        }
    }

    public IEnumerator AutoFire()
    {
        while (Input.GetButton("Fire1"))
        {
            Fire();
            yield return new WaitForSeconds(fireRate);
        }

        isFiring = false;
        gunAnimator.SetBool("isFiring", false); 
    }

    void Fire()
    {
        fireSource.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;

        gunAnimator.Play("fire", 0, 0); 
;
    }
}