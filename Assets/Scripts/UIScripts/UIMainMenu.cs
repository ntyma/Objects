using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject instructions;

    public void Start()
    {
        ShowMainMenu();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowInstructionScreen()
    {
        instructions.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        instructions.gameObject.SetActive(false);
    }
}
