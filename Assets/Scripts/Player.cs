using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : KitchenObjectHolder
{

    private BaseCounter selectCounter;
    [SerializeField] private LayerMask counterLayerMask;
    private bool isWalking = false;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    // Start is called before the first frame update
    Vector3 direction;

    public static Player Instance { get; private set; }// 静态变量来存储单例实例
    private void Awake ()
    {
        // 如果Instance已经被赋值且不是当前实例，销毁这个新创建的对象
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        gameInput.InteractHandler += GameInput_InteractHandler;//3订阅这个事件InteractHandler，当事件被触发时调用GameInput_InteractHandler方法
        gameInput.OperateHandler += GameInput_OperateHandler;
    }

    private void GameInput_OperateHandler (object sender, EventArgs e)
    {
        selectCounter?.Operate(this);
    }

    private void GameInput_InteractHandler (object sender, EventArgs e)
    {
        selectCounter?.Interact(this);
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
            isWalking = true;
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
        else
        {
            isWalking= false;
        }
    }
    private void HandleInteraction ()
    {
        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit, 2f, counterLayerMask))
        {
            if(hit.collider.TryGetComponent<BaseCounter>(out BaseCounter counter))
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
    private void SetSelectCounter (BaseCounter counter)
    {
        if (counter != selectCounter)
        {
            selectCounter?.CancelSelect();
            counter?.SelectCounter();
            selectCounter = counter;
        }
    }
}
