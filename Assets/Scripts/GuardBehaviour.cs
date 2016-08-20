using UnityEngine;
using System.Collections;

public class GuardBehaviour : MonoBehaviour {

	[SerializeField] float distanceToForget = 10;
	[SerializeField] Transform target;
	public bool chaseState;

	void Start () {
		chaseState = false;	
	}

	void Update () {
		if (Vector3.Distance( this.transform.position, target.position) > distanceToForget )
		{
			chaseState = false;
		}
		else
		{
			chaseState = true;
		}
	}

	// Gizmos
	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1.0F, 0.0F, 0.0F, 0.4F);
		Gizmos.DrawSphere(transform.position, distanceToForget);
	}
}
