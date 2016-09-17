using UnityEngine;
using System.Collections;

public class SignInGamejolt : MonoBehaviour {

    public Utility_PressButtonToChangeScene sceneChanger;

    void Update()
    {
        bool isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;
        if(isSignedIn)
        {
            reactivateSceneChanger();
            gameObject.SetActive(false);
        }
    }

	public void openUIToSign()
    {
        bool isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;

        if(!isSignedIn)
        {
            GameJolt.UI.Manager.Instance.ShowSignIn();
            sceneChanger.enabled = false;
        }
    }

    public void reactivateSceneChanger()
    {
        sceneChanger.enabled = true;
    }
}
