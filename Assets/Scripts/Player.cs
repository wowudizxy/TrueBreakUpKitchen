using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : KitchenObjectHolder
{

    private ClearCounter selectCounter;
    [SerializeField] private LayerMask counterLayerMask;
    private bool isWalking = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    // Start is called before the first frame update
    Vector3 direction;

    public static Player Instance { get; private set; }// ��̬�������洢����ʵ��
    private void Awake ()
    {
        // ���Instance�Ѿ�����ֵ�Ҳ��ǵ�ǰʵ������������´����Ķ���
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        gameInput.InteractHandler += GameInput_InteractHandler;//3��������¼�InteractHandler�����¼�������ʱ����GameInput_InteractHandler����
    }

    private void GameInput_InteractHandler (object sender, EventArgs e)
    {
        selectCounter?.Interact();
    }

    private void Update ()
    {
        direction = gameInput.GetMovementDirectionNormalized();
        HandleInteraction();
    }
    private void FixedUpdate ()
    {
        HandleMovement();
    }

    private void HandleMovement ()
    {
        
        
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
                SetSelectCounter(counter);
            }
            else
            {
                SetSelectCounter(null);
            }
        }
        else
        {
            SetSelectCounter(null);
        }
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }
    private void SetSelectCounter (ClearCounter counter)
    {
        if (counter != selectCounter)
        {
            selectCounter?.CancelSelect();
            counter?.SelectCounter();
            selectCounter = counter;
        }
    }
}
