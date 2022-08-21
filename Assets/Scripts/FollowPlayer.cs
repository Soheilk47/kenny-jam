using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float minDistance;
    [SerializeField] private float speed;
    private Transform myTransform;
    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
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
            }
            else
            {
                Quaternion xAxis = Quaternion.FromToRotation(Vector3.right, transform.position - player.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, xAxis, speed * Time.deltaTime);
                //attack
            }
        }
    }
}