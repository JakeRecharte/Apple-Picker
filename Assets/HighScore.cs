using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    [Header("Dynamic")]
    public static int highScore = 0;
    private ScoreCounter scoreCounter;
    private TextMeshProUGUI uiText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCounter.score > highScore){
            highScore = scoreCounter.score;
        }
        uiText.text = "High Score " + highScore.ToString("#,0");
    }
}
