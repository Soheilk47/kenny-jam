using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 1;
    private GameObject player;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject chest;

    private void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PCannon")
        {
            Health--;
            if (Health <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Instantiate(chest, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
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