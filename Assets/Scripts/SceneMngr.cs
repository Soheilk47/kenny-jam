using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngr : MonoBehaviour
{
    public void Menu()
    {
        StartCoroutine(LoadScene());
    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}