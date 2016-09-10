using UnityEngine;
using System.Collections;

public class DamageTarget : MonoBehaviour {

	bool targetInRange = false;

	void applyDamage(int damage)
	{
		Debug.Log ("applyDamage CALLED");
		if (targetInRange)
		{
			
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
