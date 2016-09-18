using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour {

    GameObject[] lifeImages = new GameObject[3];

    Utility_ChangeScene sceneChanger;
    int life = 3;

    void Start()
    {
        sceneChanger = Camera.main.GetComponent<Utility_ChangeScene>();
        Transform lives = GameObject.Find("Lives HUD Imgs").transform;
        lifeImages[0] = lives.GetChild(0).gameObject;
        lifeImages[1] = lives.GetChild(1).gameObject;
        lifeImages[2] = lives.GetChild(2).gameObject;
    }

	public void takeDamage(int dmg)
	{
		life -= dmg;

        lifeImages[life].SetActive(false);

		if (life <= 0)
		{
            sceneChanger.changeScene();
		}
	}
}
