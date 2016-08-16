using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

    public PlayerMovement playerMove = null;
    [Space(5)]
    public string moveHorizontalAxis = "Horizontal";
    public string moveVerticalAxis = "Vertical";

    void Update()
    {
        readMovementInput();
    }

    void readMovementInput()
    {
        playerMove.move(Input.GetAxisRaw(moveHorizontalAxis), Input.GetAxisRaw(moveVerticalAxis));
    }
}
