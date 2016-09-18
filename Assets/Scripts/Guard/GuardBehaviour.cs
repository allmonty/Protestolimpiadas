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
	[SerializeField] int damage = 1;

	[HideInInspector] public bool chaseState = false;
	[HideInInspector] public bool searchState = false;

	PlayerHoldPoster playerHoldPoster;
	Animator anim;

	bool targetSpotted = false;
	float timer = 0.0F;
	public float animationDelay = 0.75F;
	public float attackTimer;

	void Start () {
		playerHoldPoster = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHoldPoster>();
		anim = GetComponentInChildren<Animator> ();
		attackTimer = attackDelay;
		animationDelay = 0.75F;
	}

	void Update () {
		attackTimer += Time.deltaTime;

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
			if ( Vector3.Distance (this.transform.position, target.position) <= distanceToAttack && chaseState )
			{
                //attackTimer += Time.deltaTime;
				if (attackTimer >= attackDelay)
				{
					//Debug.Log ("ATACOU!");
					attackTimer = 0.0F;
					anim.SetBool ("isAttacking", true);
					StartCoroutine( damageHit(animationDelay) );
				}
			}
			else
			{
                anim.SetBool("isAttacking", false);
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

	IEnumerator damageHit(float delayToHit)
	{
		yield return new WaitForSeconds(delayToHit);

		anim.SetBool ("isAttacking", false); 
		BroadcastMessage("applyDamage", damage);
	}

	// Gizmos
	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1.0F, 0.0F, 0.0F, 0.4F);
		Gizmos.DrawSphere(transform.position, distanceToForget);
	}
}
