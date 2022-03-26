using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    public void loadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    public void loadGameScene()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameManager>().ResetGame();
    }

    public void loadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
