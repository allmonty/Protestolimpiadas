using UnityEngine;
using System.Collections;

public class GuardBehaviour : MonoBehaviour {

	[SerializeField] Transform target;
	[SerializeField] GameObject exclamationMark;
	[SerializeField] GameObject questionMark;
	[SerializeField] float distanceToForget = 10.0F;
	[SerializeField] float distanceToAttack = 1.0F;
	[SerializeField] float timeToForget = 2.0F;
	[SerializeField] float searchingTime = 2.0F;
	[SerializeField] float attackDelay = 1.5F;

	[HideInInspector] public bool chaseState = false;
	[HideInInspector] public bool searchState = false;

	PlayerHoldPoster playerHoldPoster;
	Animator anim;

	bool targetSpotted = false;
	float timer = 0.0F;
	float attackTimer = 0.0F;

	void Start () {
		playerHoldPoster = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHoldPoster>();
		anim = GetComponentInChildren<Animator> ();		
	}

	void Update () {

		// Player out of sight
		if (Vector3.Distance (this.transform.position, target.position) > distanceToForget) {
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
			} else if (searchState) {
				timer += Time.deltaTime;
				if (timer >= searchingTime) {
					searchState = false;
					questionMark.SetActive (false);
				}
				
			}
		} 
		// Player on sight
		else
		{
			// Close distance
			if (Vector3.Distance (this.transform.position, target.position) <= distanceToAttack)
			{
                anim.SetBool ("isAttacking", true);
			}
			else
			{
                anim.SetBool("isAttacking", true);
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
	}

	void OnTriggerStay(Collider other) {
		if ( other.CompareTag("Player") )
		{
			attackTimer += Time.deltaTime;
			if (attackTimer >= attackDelay)
			{
				attackTimer = 0.0F;
				anim.SetTrigger ("Attack");		
			}
		}
	}

	// Gizmos
	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1.0F, 0.0F, 0.0F, 0.4F);
		Gizmos.DrawSphere(transform.position, distanceToForget);
	}
}
