using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private PointManager pointManager;

    private void Awake()
    {
        pointManager = FindObjectOfType<PointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pointManager.IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}