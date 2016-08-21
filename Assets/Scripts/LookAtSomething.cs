using UnityEngine;
using System.Collections;

public class LookAtSomething : MonoBehaviour {

    public Transform thing;

	void Update()
    {
		transform.LookAt(transform.position + Vector3.forward);
    }
}
