﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Transform stairLooker;

    public float speed = 6f;
    public float stairJumpSpeed = 6f;

	Rigidbody playerRigidbody;

	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody>();
	}

	public void move(float h, float v)
	{
        float stairSpeedY = 0f;
        if(isWalkingInStairs() && (h != 0f || v != 0f))
        {
            stairSpeedY = stairJumpSpeed;
        }

        Vector3 movementDir = new Vector3(h, stairSpeedY, v);
		movementDir = movementDir.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movementDir);
	}

    bool isWalkingInStairs()
    {
        RaycastHit rayHit;
        if (Physics.Raycast(stairLooker.position, stairLooker.forward, out rayHit, 1f, 1 - LayerMask.NameToLayer("Stairs")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void look(float x, float y)
    {
        transform.LookAt(transform.position + new Vector3(x, 0f, y));
    }
}
