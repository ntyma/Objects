using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiHighScore;
    [SerializeField] TextMeshProUGUI uiScore;

    private int highScore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiateGameOverScreen()
    {
        SetHighScoreText();
        SetScoreText();
    }

    private void SetHighScoreText()
    {
        highScore = ScoreManager.singleton.GetHighScore();
        uiHighScore.text = highScore.ToString();
    }

    private void SetScoreText()
    {
        score = ScoreManager.singleton.totalScore;
        uiScore.text = score.ToString();
    }
}
