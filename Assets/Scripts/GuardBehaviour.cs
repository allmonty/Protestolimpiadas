using UnityEngine;
using System.Collections;

public class GuardBehaviour : MonoBehaviour {

	[SerializeField] float distanceToForget = 10;
	[SerializeField] Transform target;

	PlayerHoldPoster playerHoldPoster;

	public bool chaseState = false;
	public float timeToForget = 2.0F;
	public float timer = 0.0F;
	bool targetSpotted = false;

	void Start () {
		playerHoldPoster = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHoldPoster>();
		
	}

	void Update () {

		// Player out of sight
		if (Vector3.Distance( this.transform.position, target.position) > distanceToForget )
		{
			if (targetSpotted)
			{
				timer += Time.deltaTime;
				if (timer >= timeToForget)
				{
					chaseState = false;					
					targetSpotted = false;
					timer = 0.0F;
				}				
			}
		}
		else
		{
			timer = 0.0F;
			if (playerHoldPoster.isHoldingPoster)
			{
				chaseState = true;
				targetSpotted = true;				
			}
		}
	}

	// Gizmos
	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1.0F, 0.0F, 0.0F, 0.4F);
		Gizmos.DrawSphere(transform.position, distanceToForget);
	}
}
