using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Utility_PressButtonToChangeScene : MonoBehaviour {

    public string nextSceneName = "Game";

    public string buttonName = "Submit";

	void Update()
    {
        if(Input.GetButtonDown(buttonName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
