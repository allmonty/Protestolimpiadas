using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreTxtGUI;
    public int score = 0;
    public float delayToWinPoint = 0.1f;
    public int pointPerDelay = 1;

    PlayerHoldPoster playerHoldPoster;
    public bool playerIsOnCamera = false;

    bool canWinPoint = true;

    void Start()
    {
        playerHoldPoster = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHoldPoster>();
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
        scoreTxtGUI.text = "" + score;
        canWinPoint = true;
    }

    public void setPlayerIsOnCamera(bool value)
    {
        playerIsOnCamera = value;
    }
}
