using UnityEngine;
using System.Collections;

public class GuardMovement : MonoBehaviour {

	public Transform target;
	[Tooltip("Time to wait between patrol route waypoints.")]
	[SerializeField] float waitingTime;
	[SerializeField] Transform[] routeWaypoints;

	[Header("Speed Parameters")]
	[SerializeField] float patrollingSpeed = 2.5F;
	[SerializeField] float chaseSpeed = 3.5F;

	[SerializeField] float targetDistanceThreshold = 2.3F;

	NavMeshAgent agent;
	GuardBehaviour guardBehaviour;
	Animator anim;

	int nextWaypoint;
	float timer = 0.0F;
	float waypointThreshold = 0.01F;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		guardBehaviour = GetComponent<GuardBehaviour>();
		anim = GetComponentInChildren<Animator>();

		nextWaypoint = Random.Range (0, routeWaypoints.Length);
		agent.Warp(routeWaypoints[nextWaypoint].position);
	}

	void Update () {
		if (guardBehaviour.chaseState) {
			chase ();
		} 
		else if (guardBehaviour.searchState)
		{
			search ();
		}
		else
		{
			patrol ();
		}
	}

	void chase() {
		agent.destination = target.position;
		if (Vector3.Distance (agent.transform.position, agent.destination) <= targetDistanceThreshold) {
			Debug.Log ("Perto demais!");
			agent.Stop ();
		}
		else { 
			agent.Resume ();
			agent.speed = chaseSpeed;
			anim.SetBool ("isChasing", true);
		}
	}

	void search() {
		agent.Stop();
		anim.SetBool ("isChasing", false);
		anim.SetBool ("isPatrolling", false);
	}

	void patrol() {
		agent.Resume();
		agent.destination = routeWaypoints[nextWaypoint].position;
		agent.speed = patrollingSpeed;
		anim.SetBool ("isPatrolling", true);
		Vector3 normalizedWaypointPos = new Vector3 (agent.destination.x, transform.position.y, agent.destination.z);

		if (Vector3.Distance (transform.position, normalizedWaypointPos) <= waypointThreshold)
		{
			transform.LookAt(transform.position + Vector3.back);
			anim.SetBool ("isPatrolling", false);

			timer += Time.deltaTime;
			if (timer >= waitingTime) {
				timer = 0.0F;
				nextWaypoint = Random.Range (0, routeWaypoints.Length);	
			}
		}
	}

}
