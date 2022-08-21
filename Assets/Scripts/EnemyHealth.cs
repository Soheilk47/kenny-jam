using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 1;
    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
    }

    public int DecreaseHealth()
    {
        Health--;
        return Health;
    }

    private void Update()
    {
        StartCoroutine(DistanceDestroy());
    }

    private IEnumerator DistanceDestroy()
    {
        yield return new WaitForSeconds(4f);
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > 400f)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DistanceDestroy());
        }
    }
}