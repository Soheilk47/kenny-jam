using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    [SerializeField] private int heartsCount = 3;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Awake()
    {
        health = heartsCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ECannon")
        {
            health -= 1;
            HealthSystem();
            if (health <= 0)
            {
                die();
            }
            Destroy(collision.gameObject);
        }
    }

    private void die()
    {
        //fillll
    }

    private void HealthSystem()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < heartsCount)
            {
                hearts[i].enabled = true;
            }
            else { hearts[i].enabled = false; }
        }
    }
}