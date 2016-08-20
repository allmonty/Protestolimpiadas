using UnityEngine;
using System.Collections;

public class GuardBehaviour : MonoBehaviour {

	[SerializeField] float distanceToForget = 10;
	[SerializeField] Transform target;

	public bool chaseState;
	public float timeToForget;
	public float timer;
	bool targetSpotted = false;

	void Start () {
		chaseState = false;	
		timeToForget = 2.0F;
		timer = 0.0F;
	}

	void Update () {
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
			chaseState = true;
			targetSpotted = true;
		}
	}

	// Gizmos
	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1.0F, 0.0F, 0.0F, 0.4F);
		Gizmos.DrawSphere(transform.position, distanceToForget);
	}
}
