using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public bool isGameOver = false;
    [SerializeField] private MenuCanvas menuCanvas = null;
    //[SerializeField] private GameObject menuCanvasGO = null;

    private void Update()
    {
        if (isGameOver == true)
        {
            menuCanvas.GameOver();
            //menuCanvasGO.GetComponent<MenuCanvas>().GameOver();
        }
    }

    public void AddToScore()
    {
        score++;
        menuCanvas.UpdateScoreText(score);

        /*
        REMINDER: 
        we want each script to have its own job.
        that's why in this case the game manager doesn't change the score UI,
        it tells another script (MenuCanvas) to do that.
        MenuCanas is the script in charge of UI.
        */
    }
}
