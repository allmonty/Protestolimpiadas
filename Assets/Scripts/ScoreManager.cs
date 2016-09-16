using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    [SerializeField] Text scoreTxtGUI;

    PlayerHoldPoster playerHoldPoster;

    [SerializeField] float delayToWinPoint = 0.1f;
    [SerializeField] int pointPerDelay = 1;

    [SerializeField]int score = 0;
    
    bool playerIsOnCamera = false;
    bool canWinPoint = true;

    void Start()
    {
        playerHoldPoster = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHoldPoster>();


        SpecialSingleton.Instances["GameScore"].addEvent(new UnityAction(showScoreInEndScene));
    }

    void Update()
    {
        if(playerIsOnCamera && playerHoldPoster.isHoldingPoster)
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

    void showScoreInEndScene()
    {
        if(SceneManager.GetActiveScene().name.Equals("EndGame"))
        {
            GameObject pointsHUD = GameObject.Find("Points");
            pointsHUD.GetComponent<Text>().text = score.ToString("000000");
        }
        
        string scoreText = score + " protestadas"; // A string representing the score to be shown on the website.
        int tableID = 186722; // Set it to 0 for main highscore table.
        string extraData = ""; // This will not be shown on the website. You can store any information.

        GameJolt.API.Scores.Add(score, scoreText, tableID, extraData, (bool success) => {
            Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
        });
    }

    public void setPlayerIsOnCamera(bool value)
    {
        playerIsOnCamera = value;
    }
}
