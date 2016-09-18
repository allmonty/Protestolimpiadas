using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    PlayerHoldPoster playerHoldPoster;
    Text scoreTxtGUI;

    [SerializeField] float delayToWinPoint = 0.1f;
    [SerializeField] int pointPerDelay = 1;

    [SerializeField] int score = 0;
    
    bool playerIsOnCamera = false;

    bool canWinPoint = true;
    bool isOnGameScene = true;

    void Update()
    {
        if(isOnGameScene && playerIsOnCamera && playerHoldPoster.isHoldingPoster)
        {
            if(canWinPoint)
            {
                canWinPoint = false;
                Invoke("winPoint", delayToWinPoint);
            }
        }
    }

    void winPoint()
    {
        score += pointPerDelay;
        scoreTxtGUI.text = score.ToString("000000");
        canWinPoint = true;
    }

    public void initializeScoreInGameScene()
    {
        if (SceneManager.GetActiveScene().name.Equals("Game"))
        {
            isOnGameScene = true;

            score = 0;

            playerHoldPoster = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHoldPoster>();
            scoreTxtGUI = GameObject.Find("Score HUD Text").GetComponent<Text>();
        }
    }

    public void showScoreInEndScene()
    {
        if(SceneManager.GetActiveScene().name.Equals("EndGame"))
        {
            isOnGameScene = false;

            GameObject pointsHUD = GameObject.Find("Points");
            pointsHUD.GetComponent<Text>().text = score.ToString("000000");

            //=====GAMEJOLT API=====//
            string scoreText = score + " protestadas"; // A string representing the score to be shown on the website.
            int tableID = 186722; // Set it to 0 for main highscore table.
            string extraData = ""; // This will not be shown on the website. You can store any information.
            GameJolt.API.Scores.Add(score, scoreText, tableID, extraData, (bool success) => {
                Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
            });
            //=====END OF GAMEJOLT API=====//

        }
    }

    public void setPlayerIsOnCamera(bool value)
    {
        playerIsOnCamera = value;
    }
}
