using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public void setPlayerIsOnCamera(bool value)
    {
        playerIsOnCamera = value;
    }
}
