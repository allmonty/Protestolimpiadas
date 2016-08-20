using UnityEngine;
using System.Collections;

public class PlayerHoldPoster : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void startHolding()
    {
        anim.SetBool("IsHoldingPoster", true);
    }

    public void stopHolding()
    {
        anim.SetBool("IsHoldingPoster", false);
    }
}
