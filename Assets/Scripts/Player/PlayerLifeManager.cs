using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour {

	[SerializeField] int life = 3;

    Utility_ChangeScene sceneController;

    void Start()
    {
        sceneController = Camera.main.GetComponent<Utility_ChangeScene>();
    }

	public void takeDamage(int dmg)
	{
		life -= dmg;

		if (life <= 0)
		{
            //Player is dead
            sceneController.changeScene();
		}
	}

}
