using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [SerializeField] Text outputText;
	[SerializeField] float gameDuration = 90.0f;

    Utility_ChangeScene sceneChanger;

    float timer = 0f;

    int minutes = 0;
    int seconds = 0;
    
    void Start()
    {
        timer = gameDuration;

        sceneChanger = Camera.main.GetComponent<Utility_ChangeScene>();
    }

    void Update()
    {
        if(timer <= 0f){
            endGame();
        }
        else
        {
            timer -= Time.deltaTime;

            computeTime();
            renderTimeInScene();
        }
    }

    void computeTime()
    {
        seconds = (int) timer;
        minutes = seconds / 60;
        seconds = seconds % 60;
    }

    void renderTimeInScene()
    {
        outputText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); 
    }

    void endGame()
    {
        sceneChanger.changeScene();
    }
}
