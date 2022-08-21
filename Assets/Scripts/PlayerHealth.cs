using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    [SerializeField] private int heartsCount = 3;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private GameObject explosion;

    private void Awake()
    {
        health = heartsCount;
        HealthSystem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ECannon")
        {
            health -= 1;
            HealthSystem();
            if (health <= 0)
            {
                die();
            }
            Invoke("resetPosition", 1f);
            Destroy(other.gameObject);
        }
    }

    private void resetPosition()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = new Vector3(0, -40, 0);
    }

    private void die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<SceneMngr>().Menu();
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