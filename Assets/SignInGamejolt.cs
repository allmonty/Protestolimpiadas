using UnityEngine;
using System.Collections;

public class SignInGamejolt : MonoBehaviour {

    public Utility_PressButtonToChangeScene sceneChanger;

    void Start()
    {
        bool isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;
        if(isSignedIn)
        {
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
