using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;

	Rigidbody playerRigidbody;

	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody>();
	}

	public void move(float h, float v)
	{
        Vector3 movementDir = new Vector3(h, 0f, v);
		movementDir = movementDir.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movementDir);
	}
}
