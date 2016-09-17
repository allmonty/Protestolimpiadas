using UnityEngine;
using System.Collections;

public class DamageTarget : MonoBehaviour {

	[SerializeField] GameObject target;
	[SerializeField] AudioSource hitSFX;


	PlayerLifeManager pManager;
	bool targetInRange = false;

	void Start()
	{
		pManager = target.GetComponentInChildren<PlayerLifeManager>();
		hitSFX = GetComponentInChildren<AudioSource> ();
	}


	void applyDamage(int damage)
	{
		if (targetInRange)
		{
			hitSFX.Play();
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
