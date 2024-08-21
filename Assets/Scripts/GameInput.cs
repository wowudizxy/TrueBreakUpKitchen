using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameControl gameContral;
    private void Start ()
    {
        gameContral = new GameControl();
        gameContral.Player.Enable();

    }
    public Vector3 GetMovementDirectionNormalized ()
    {
        Vector2 dirVector2 = gameContral.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(dirVector2.x, 0, dirVector2.y).normalized;
        return direction;
    }
}
