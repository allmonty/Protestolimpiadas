using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SingletonDontDestroyOnLoad : MonoBehaviour {

    static public SingletonDontDestroyOnLoad Instance;

    private GameObject target;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (Instance != null)
        {
            if (Instance != this)
            {
                SceneManager.sceneLoaded -= sceneLoaded;
                Destroy(this);
                Destroy(gameObject);
            }
        }
        else
        {
            Instance = this;
        }
    }

    void sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        target = GameObject.Find(gameObject.name);
        if (target == null)
        {
            throw new System.Exception("The main camera needs vignette script!!");
        }
    }
}
