using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    [SerializeField] private int totalScore;
    [SerializeField] private int highestScore;

    public UnityEvent<int> OnTotalScoreChanged = new UnityEvent<int>();
    public UnityEvent<int> OnHighestScoreChanged = new UnityEvent<int>();

    private void Awake()
    {
        singleton = this;
        highestScore = PlayerPrefs.GetInt("HSCORE"); //retrieving save file with the name HSCORE
    }
    public void IncreaseScore()
    {
        totalScore += 1;
        OnTotalScoreChanged.Invoke(totalScore);
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
}
