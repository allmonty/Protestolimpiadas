using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Utility_PressButtonToChangeScene : MonoBehaviour {

    public string nextSceneName = "Game";
    public string buttonName = "Submit";
    public float delay = 1f;

    SceneTransition_Vignetting transitionVignette;

    void Start()
    {
        GameObject screenTransition = GameObject.FindGameObjectWithTag("ScreenTransition");
        if(screenTransition != null)
        {
            transitionVignette = screenTransition.GetComponent<SceneTransition_Vignetting>();
        }
        else
        {
            throw new System.Exception("Need the SceneTransition_Vignetting script somewhere in scene!!!");
        }
    }

	void Update()
    {
        if(Input.GetButtonDown(buttonName))
        {
            if(transitionVignette != null)
            {
                transitionVignette.closeVignette(delay);
            }
            Invoke("changeScene", delay);
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
