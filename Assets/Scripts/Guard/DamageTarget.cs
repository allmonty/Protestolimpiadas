using UnityEngine;
using System.Collections;

public class DamageTarget : MonoBehaviour {

	[SerializeField] GameObject target;
	bool targetInRange = false;
	PlayerManagement pManager;

	void Start()
	{
		pManager = target.GetComponentInChildren<PlayerManagement>();
	}


	void applyDamage(int damage)
	{
		if (targetInRange)
		{
			Debug.Log ("applyDamage CALLED");
			pManager.takeDamage(damage);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if( other.CompareTag ("Player") ) 
		{
			targetInRange = true;
		}		
	}

	void OnTrigerExit(Collider other)
	{		
		if( other.CompareTag ("Player") ) 
		{
			targetInRange = false;
		}		
	}
}
