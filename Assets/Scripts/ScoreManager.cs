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
    }

    public void setPlayerIsOnCamera(bool value)
    {
        playerIsOnCamera = value;
    }
}
