using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

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
        canWinPoint = true;
    }

    public void setPlayerIsOnCamera(bool value)
    {
        playerIsOnCamera = value;
    }
}
