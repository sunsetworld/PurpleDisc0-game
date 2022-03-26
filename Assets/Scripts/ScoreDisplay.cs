using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{

    TextMeshProUGUI scoreText;
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is call   ed once per frame
    void Update()
    {
        scoreText.text = gameManager.GetScore().ToString();
    }
}
