using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2d : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed;
    Vector3 direction;
    private void Update()
    {
        direction = gameInput.GetMovement2dNormalized();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        transform.position += direction * Time.deltaTime * moveSpeed;
        if (direction != Vector3.zero)
        {
            transform.localScale = new Vector3(-direction.x, 1, 1); // œÚ”““∆∂Ø
        }
        else
        {
        }
    }
}
