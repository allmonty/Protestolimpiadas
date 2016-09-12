using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLifeManager : MonoBehaviour {

	[SerializeField] int life = 3;

	public void takeDamage(int dmg)
	{
		life -= dmg;

		if (life <= 0)
		{
			Debug.Log ("Player is dead. Game over.");
			SceneManager.LoadScene("EndGame");
		}

	}

}
