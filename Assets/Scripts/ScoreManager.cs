using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    [SerializeField] bool playerIsOnCamera = false;

    public void setPlayerIsOnCamera(bool value)
    {
        playerIsOnCamera = value;
    }
}
