using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu = null;
    [SerializeField] private GameObject GameOverMenu = null;
    [SerializeField] private Text scoreText;
    
    public GameObject playerRef;

    // makes the player start running and disables the start game UI
    public void StartGame()
    {
        //playerRef.GetComponent<PlayerController>().enabled = true;
        playerRef.GetComponent<PlayerController>().StartRunning();
        StartMenu.SetActive(false);
    }

    // makes the player stop running and enables the game over UI
    public void GameOver()
    {
        // playerRef.GetComponent<PlayerController>().enabled = false;
        playerRef.GetComponent<PlayerController>().StopRunning();
        GameOverMenu.SetActive(true);
    }

    // restarts the scene
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // quits the game. doesn't work in the editor, only in an exe build
    public void Exit()
    {
        Application.Quit();
    }

    // update the UI text that displayed the current score
    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }


}
