using UnityEngine;
using System.Collections;

public class GuardBehaviour : MonoBehaviour {

	[SerializeField] float distanceToForget = 10;
	[SerializeField] Transform target;
	[SerializeField] GameObject exclamationMark;
	[SerializeField] GameObject questionMark;

	PlayerHoldPoster playerHoldPoster;

	public bool chaseState = false;
	public bool searchState = false;
	bool targetSpotted = false;

	public float timeToForget = 2.0F;
	public float searchingTime = 2.0F;
	public float timer = 0.0F;

	void Start () {
		playerHoldPoster = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHoldPoster>();
		
	}

	void Update () {

		// Player out of sight
		if (Vector3.Distance( this.transform.position, target.position) > distanceToForget )
		{
			if (targetSpotted) {
				timer += Time.deltaTime;
				if (timer >= timeToForget) {
					chaseState = false;			
					targetSpotted = false;
					searchState = true;
					timer = 0.0F;

					exclamationMark.SetActive (false);
					questionMark.SetActive (true);
				}				
			}
			else if(searchState)
			{
				timer += Time.deltaTime;
				if (timer >= searchingTime)
				{
					searchState = false;
					questionMark.SetActive(false);
				}
				
			}
		}
		// Player on sight
		else
		{
			timer = 0.0F;
			if (playerHoldPoster.isHoldingPoster || searchState) {
				chaseState = true;
				searchState = false;
				targetSpotted = true;

				exclamationMark.SetActive (true);
				questionMark.SetActive (false);
			}

		}
	}

	void searchTarget()
	{
		
	}

	// Gizmos
	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1.0F, 0.0F, 0.0F, 0.4F);
		Gizmos.DrawSphere(transform.position, distanceToForget);
	}
}
