using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeMusicOnLoadScene : MonoBehaviour {

    [SerializeField] AudioSource musicA = null;
    [SerializeField] AudioSource musicB = null;

    [SerializeField] string AToBScene = "";
    [SerializeField] string BToAScene = "";

    [SerializeField] float transitionDuration = 1f;

    float timer = 0f;

    public void onSceneChange()
    {
        if(SceneManager.GetActiveScene().name.Equals(AToBScene))
        {
            fadeMusic(musicA, musicB);
        }

        if(SceneManager.GetActiveScene().name.Equals(BToAScene))
        {
            fadeMusic(musicB, musicA);
        }
    }

    void fadeMusic(AudioSource from, AudioSource to)
    {
        StopCoroutine("doFadeMusic");
        StartCoroutine(doFadeMusic(from, to));
    }

    IEnumerator doFadeMusic(AudioSource from, AudioSource to)
    {
        to.Play();

        while(timer <= transitionDuration)
        {
            timer += Time.deltaTime;
            float percentage = timer / transitionDuration;

            to.volume = percentage;
            from.volume = 1 - percentage;

            Debug.Log("oi: " + percentage);

            yield return null;
        }

        from.Stop();
        timer = 0f;
    }
}
