using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class SceneTransition_Vignetting : SingletonBehaviour {

    static public SingletonBehaviour Instance;

    public float openTimeDefault = 1f;
    public float closeTimeDefault = 1f;

    [Space(10)]

    VignetteAndChromaticAberration targetVignette;

    [SerializeField] float effectSpeed = 1.0f;
    [SerializeField] float vignetting = 0f;
    [SerializeField] int control = 0; //0 = stopped; 1 = opening; 2 = closing;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += sceneLoaded;
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
        targetVignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
        if (targetVignette == null)
        {
            throw new System.Exception("The main camera needs vignette script!!");
        }

        openVignette();
    }

    void Update()
    {
        if (control == 1)//open
        {
            vignetting = Mathf.MoveTowards(vignetting, 0f, effectSpeed * Time.deltaTime);
            targetVignette.intensity = vignetting;
            if (vignetting <= 0f)
            {
                stopVignetting();
            }
        }
        if (control == 2)//close
        {
            vignetting = Mathf.MoveTowards(vignetting, 1f, effectSpeed * Time.deltaTime);
            targetVignette.intensity = vignetting;
            if(vignetting >= 1f)
            {
                stopVignetting();
            }
        }
    }

    public void stopVignetting()
    {
        control = 0;
    }

    public void openVignette()
    {
        control = 1;
        vignetting = 1f;
        effectSpeed = 1f / openTimeDefault;
    }

    public void openVignette(float dtime)
    {
        control = 1;
        vignetting = 1f;
        effectSpeed = 1f / dtime;
    }

    public void closeVignette()
    {
        control = 2;
        vignetting = 0f;
        effectSpeed = 1f / closeTimeDefault;
    }

    public void closeVignette(float dtime)
    {
        control = 2;
        vignetting = 0f;
        effectSpeed = 1f / dtime;
    }
}
