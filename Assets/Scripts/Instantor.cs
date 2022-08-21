using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantor : MonoBehaviour
{
    public GameObject[] gameObjects;

    [SerializeField] private float respawnTime = 10;
    private float respawnTimeP;

    private PointManager pointManager;

    private void Awake()
    {
        pointManager = FindObjectOfType<PointManager>();
    }

    private void Update()
    {
        if (respawnTimeP < 0)
        {
            if (pointManager.score / 5 < gameObjects.Length)
            {
                for (int i = 0; i < pointManager.score / 5 + 1; i++)
                {
                    Vector3 x = GetRandomNumber();

                    Instantiate(gameObjects[i], transform.position + x, Quaternion.identity);
                }
            }
            else
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    Vector3 x = GetRandomNumber();

                    Instantiate(gameObjects[i], transform.position + x, Quaternion.identity);
                }
            }

            respawnTimeP = respawnTime;
        }
        else
        {
            respawnTimeP -= Time.deltaTime;
        }
    }

    private Vector3 GetRandomNumber()
    {
        float random1 = Random.Range(100, 150);
        if (Random.value < 0.5)
        {
            random1 *= -1;
        }
        float random2 = Random.Range(100, 150);
        if (Random.value < 0.5)
        {
            random2 *= -1;
        }
        float random3 = Random.Range(-100, 100);

        if (Random.value < 0.2)
        {
            return new Vector3(random1, transform.position.y, random2);
        }
        if (Random.value > 0.2)
        {
            return new Vector3(random3, transform.position.y, random2);
        }
        else
        {
            return new Vector3(random1, transform.position.y, random3);
        }
    }
}