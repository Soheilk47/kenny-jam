using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float minDistance;
    [SerializeField] private float speed;
    private Transform myTransform;
    private Transform player;
    private EnemyShoot enemyShoot;
    private Vector3 shootPos;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemyShoot = GetComponent<EnemyShoot>();
    }

    private void Start()
    {
        myTransform = this.transform;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            if (Vector3.Distance(myTransform.position, player.position) >= minDistance)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(transform.position - player.position);
                shootPos = player.position;
            }
            else if (Vector3.Distance(myTransform.position, player.position) <= minDistance + 30)

            {
                Quaternion xAxis = Quaternion.FromToRotation(Vector3.right, transform.position - player.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, xAxis, speed * Time.deltaTime * 10);
                enemyShoot.Shooting(shootPos);
            }
        }
    }
}