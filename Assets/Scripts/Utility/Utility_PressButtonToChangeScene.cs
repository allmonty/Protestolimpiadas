using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Utility_PressButtonToChangeScene : Utility_ChangeScene {

    public string buttonName = "Submit";

    void Update()
    {
        if(Input.GetButtonDown(buttonName))
        {
            changeScene();
        }
    }
}
