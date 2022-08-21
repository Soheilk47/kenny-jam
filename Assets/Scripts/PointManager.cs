using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score = 0;
    public GameObject[] upgrades;
    public int[] levelPoints;

    public TMP_Text scoreObj;

    public int IncreaseScore(int points)
    {
        score += points;
        scoreObj.text = score.ToString();
        Upgrade();
        return score;
    }

    private void Upgrade()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (score >= levelPoints[i])
            {
                upgrades[i].SetActive(true);
                if (i > 0)
                {
                    upgrades[i - 1].SetActive(false);
                }
            }
            else { upgrades[i].SetActive(false); }
        }
    }
}