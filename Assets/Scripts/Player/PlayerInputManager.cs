using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

    public PlayerMovement playerMove = null;
    public PlayerHoldPoster playerHoldPoster = null;
    [Space(5)]
    public string moveHorizontalAxis = "Horizontal";
    public string moveVerticalAxis = "Vertical";

    void Update()
    {
        readMovementInput();
        readHoldPosterCommand();
    }

    void readMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw(moveHorizontalAxis), Input.GetAxisRaw(moveVerticalAxis));
        playerMove.move(input.x, input.y);
        playerMove.look(input.x, input.y);
    }

    void readHoldPosterCommand()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            playerHoldPoster.startHolding();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            playerHoldPoster.stopHolding();
        }
    }
}
