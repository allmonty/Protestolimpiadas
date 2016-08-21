using UnityEngine;
using System.Collections;

public class LookAtSomething : MonoBehaviour {

    public Transform thing;

	void Update()
    {
        transform.LookAt(thing.position);
    }
}
