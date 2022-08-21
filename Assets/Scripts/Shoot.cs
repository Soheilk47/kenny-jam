using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPosL;
    [SerializeField] private Transform[] shootPosR;

    [SerializeField] private float shootTimer = 1;
    private float shootTimerP;

    [SerializeField] private float bulletSpeed = 3f;

    [SerializeField] private Image ShootCooldown;

    private void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (shootTimerP < 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                for (int i = 0; i < shootPosL.Length; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, shootPosL[i].position, Quaternion.identity);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(transform.right * bulletSpeed, ForceMode.Impulse);
                    Destroy(bullet, 4f);
                    shootTimerP = shootTimer;
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < shootPosR.Length; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, shootPosR[i].position, Quaternion.identity);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(-transform.right * bulletSpeed, ForceMode.Impulse);
                    Destroy(bullet, 4f);
                    shootTimerP = shootTimer;
                }
            }
        }
        else
        {
            shootTimerP -= Time.deltaTime;
            CooldownImage();
        }
    }

    private void CooldownImage()
    {
        float fillFraction = 1 - shootTimerP / shootTimer;
        ShootCooldown.fillAmount = fillFraction;
    }
}