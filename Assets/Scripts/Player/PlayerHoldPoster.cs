using UnityEngine;
using System.Collections;

public class PlayerHoldPoster : MonoBehaviour {

    public bool isHoldingPoster = false;

    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void startHolding()
    {
        isHoldingPoster = true;
        anim.SetBool("IsHoldingPoster", isHoldingPoster);
        transform.LookAt(transform.position + Vector3.back);
    }

    public void stopHolding()
    {
        isHoldingPoster = false;
        anim.SetBool("IsHoldingPoster", isHoldingPoster);
    }
}
