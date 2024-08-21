using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private bool isWalking = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = gameInput.GetMovementDirectionNormalized();
        isWalking = direction!= Vector3.zero;
        transform.position += direction * Time.deltaTime * moveSpeed;
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
        
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }
}
