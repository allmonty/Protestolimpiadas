using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Utility_ChangeScene : MonoBehaviour {

    public string nextSceneName = "Game";

    public float effectTime = 0.5f;
    public float delaySceneChange = 0.7f;

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

    public void changeScene()
    {
        if (transitionVignette != null)
        {
            transitionVignette.closeVignette(effectTime);
        }
        Invoke("doChangeScene", delaySceneChange);
    }

    public void changeScene(string nextScene)
    {
        nextSceneName = nextScene;
        changeScene();
    }

    void doChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
