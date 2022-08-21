using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPos;

    [SerializeField] private float shootTimer = 1;
    private float shootTimerP;

    [SerializeField] private float bulletSpeed = 3f;

    public void Shooting(Vector3 targetPos)
    {
        if (shootTimerP < 0)
        {
            for (int i = 0; i < shootPos.Length; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootPos[i].position, Quaternion.identity);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(-transform.right * bulletSpeed, ForceMode.Impulse);
                Destroy(bullet, 4f);
                shootTimerP = shootTimer;
            }
        }
        else
        {
            shootTimerP -= Time.deltaTime;
        }
    }
}