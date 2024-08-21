using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask counterLayerMask;
    private bool isWalking = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update ()
    {
        HandleInteraction();
    }
    private void FixedUpdate ()
    {
        HandleMovement();
    }

    private void HandleMovement ()
    {
        Vector3 direction = gameInput.GetMovementDirectionNormalized();
        isWalking = direction != Vector3.zero;
        transform.position += direction * Time.deltaTime * moveSpeed;
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
    }
    private void HandleInteraction ()
    {
        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit, 2f, counterLayerMask))
        {
            if(hit.collider.TryGetComponent<ClearCounter>(out ClearCounter counter))
            {
                counter.Interact();
            }
        }
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }
}
