using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIGamePlay uiGamePlay;
    [SerializeField] private UIGameOver uiGameOver;


    // Start is called before the first frame update
    void Start()
    {
        SetGamePlayScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameOverScreen()
    {
        uiGamePlay.gameObject.SetActive(false);
        uiGameOver.InitiateGameOverScreen();
        uiGameOver.gameObject.SetActive(true);
    }

    public void SetGamePlayScreen()
    {
        uiGameOver.gameObject.SetActive(false);
        uiGamePlay.gameObject.SetActive(true);
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        SetGamePlayScreen();
    }
}
