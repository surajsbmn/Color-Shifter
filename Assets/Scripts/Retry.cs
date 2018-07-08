using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retry : MonoBehaviour {

    public static bool isGameEnded = false;
    public static bool isPlayerWon = false;

    public GameObject retryUI;
    public GameObject winMessgageUI;
    public Text score;

    void Update()
    {
        if (isGameEnded)
        {
            ShowRetry();
        }

        if (isPlayerWon)
        {
            ShowWinMessage();
        }
 
    }
    public void RetryGame()
    {
        retryUI.SetActive(false);
        isGameEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShowRetry()
    {
        
        score.text ="Score: " + Player.score.ToString();
        retryUI.SetActive(true);
        Time.timeScale = 0f;
        
    }
        
    public void Menu()
    {
        retryUI.SetActive(false);
        isGameEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void ShowWinMessage()
    {
        Time.timeScale = 0f;
        winMessgageUI.SetActive(true);
    }
       
}
