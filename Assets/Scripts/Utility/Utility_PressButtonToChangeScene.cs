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
        transitionVignette = GameObject.FindGameObjectWithTag("ScreenTransition").GetComponent<SceneTransition_Vignetting>();
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
