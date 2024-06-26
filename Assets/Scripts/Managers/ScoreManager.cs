using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    [SerializeField] public int totalScore;
    [SerializeField] private int highestScore;

    public UnityEvent<int> OnTotalScoreChanged = new UnityEvent<int>();
    public UnityEvent<int> OnHighestScoreChanged = new UnityEvent<int>();
    public UnityEvent<int> OnScoreReached = new UnityEvent<int>();

    private void Awake()
    {
        singleton = this;
        highestScore = PlayerPrefs.GetInt("HSCORE"); //retrieving save file with the name HSCORE
    }

    public void IncreaseScore()
    {
        totalScore += 1;
        OnTotalScoreChanged.Invoke(totalScore);
        if(totalScore == 25 || totalScore == 50 || totalScore == 100)
        {
            OnScoreReached.Invoke(totalScore);
        }
    
    }

    public void RegisterHighscore()
    {
        if(totalScore > highestScore)
        {
            PlayerPrefs.SetInt("HSCORE", totalScore);
            highestScore = totalScore;
            OnHighestScoreChanged.Invoke(highestScore);
        }
    }

    public int GetHighScore()
    {
        return highestScore;
    }
    
}
