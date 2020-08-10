using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public GameObject gameOverUI;

    public void EndGame() {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        GameObject.Find("FinalScore").GetComponent<Text>().text = "Score: " + PlayerMovement.score.ToString();
        GameObject.Find("ScoreUI").SetActive(false);
    }

    public void Restart() {
        PlayerMovement.score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
