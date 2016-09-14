using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour {

    [SerializeField] GameObject[] lifeImages;

    Utility_ChangeScene sceneChanger;
    int life = 3;

    void Start()
    {
        sceneChanger = Camera.main.GetComponent<Utility_ChangeScene>();
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
