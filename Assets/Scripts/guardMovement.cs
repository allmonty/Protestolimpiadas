using UnityEngine;
using System.Collections;

public class GuardMovement : MonoBehaviour {

	public Transform target;
	public float waitingTime;
	[SerializeField] Transform[] routeWaypoints;

	NavMeshAgent agent;
	GuardBehaviour guardBehaviour;
	int nextWaypoint;
	float timer = 0.0F;
	float waypointThreshold = 0.01F;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		guardBehaviour = GetComponent<GuardBehaviour>();

		nextWaypoint = Random.Range (0, routeWaypoints.Length);
		transform.position = routeWaypoints[nextWaypoint].position;
	}
	
	// Update is called once per frame
	void Update () {
		if (guardBehaviour.chaseState)
		{
			agent.destination = target.position;	
		} else
		{
			agent.destination = routeWaypoints[nextWaypoint].position;
			Vector3 normalizedWaypointPos = new Vector3 (agent.destination.x, transform.position.y, agent.destination.z);

			if (Vector3.Distance (transform.position, normalizedWaypointPos) <= waypointThreshold)
			{
				transform.LookAt(transform.position + Vector3.back);

				timer += Time.deltaTime;
				if (timer >= waitingTime) {
					timer = 0.0F;
					nextWaypoint = Random.Range (0, routeWaypoints.Length);	
				}
			}
		}
	}
}
