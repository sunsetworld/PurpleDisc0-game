using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score = 0;
    float health = 0;
    void Awake()
    {
        SetupSingleton();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    void SetupSingleton()
    {
        int numberGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numberGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
