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
                transform.position += transform.forward * speed * Time.deltaTime;
                Vector3 targetPos = new Vector3(player.transform.position.x, transform.position.y, player.position.z);
                myTransform.LookAt(targetPos * -1);
            }
            else
            {
                transform.rotation *= Quaternion.Euler(0, 90f * speed * Time.deltaTime, 0);
                //attack
            }
        }
    }
}