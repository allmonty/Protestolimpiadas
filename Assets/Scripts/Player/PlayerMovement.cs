using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;

    PlayerHoldPoster playerHoldPoster;
	Rigidbody playerRigidbody;
    Animator anim;

	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody>();
        playerHoldPoster = GetComponent<PlayerHoldPoster>();
        anim = GetComponentInChildren<Animator>();
	}

	public void move(float h, float v)
	{
        if (playerHoldPoster.isHoldingPoster) return;

        if(h != 0f || v != 0f)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        Vector3 movementDir = new Vector3(h, 0f, v);
		movementDir = movementDir.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movementDir);
	}

    public void look(float x, float y)
    {
        if (playerHoldPoster.isHoldingPoster) return;

        transform.LookAt(transform.position + new Vector3(x, 0f, y));
    }
}
