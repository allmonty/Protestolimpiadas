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
        Vector2 input = new Vector2(Input.GetAxisRaw(moveHorizontalAxis), Input.GetAxisRaw(moveVerticalAxis));
        playerMove.move(input.x, input.y);
        playerMove.look(input.x, input.y);
    }
}
