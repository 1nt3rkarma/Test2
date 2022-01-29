using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFunctions : MonoBehaviour
{
    bool isPaused = false;

    [HideInInspector]
    [SerializeField] GameObject pause;
    [HideInInspector]
    [SerializeField] GameObject continueGame;
    [HideInInspector]
    [SerializeField] GameObject menu;

    [SerializeField] GameObject score;

    private void Start()
    {
        pause.SetActive(false);
        continueGame.SetActive(true);
        score.SetActive(true);
    }

    private void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;

            isPaused = false;
            pause.SetActive(true);
            continueGame.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;

            isPaused = true;
            pause.SetActive(false);
            continueGame.SetActive(true);
        }
    }


    //не могу юзать в другом классе(((
    public void GameOver()
    {
        Time.timeScale = 0;

        pause.SetActive(false);
        menu.SetActive(true);
        score.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);

        //сразу, как начинается новая игра нужно запускать мячик,
        //если занести в старт сетод Move, то это не решает задачу
    }
}
