using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OperateHandler;
    public event EventHandler InteractHandler;//1声明一个用于交互的事件，event 关键字用来声明一个事件。事件是基于委托类型的，但与普通委托不同，事件只能在其定义的类中被触发（即调用），而其他类只能订阅（+=）或取消订阅（-=）这个事件。
    private GameControl gameContral;
    private void Start ()
    {
        gameContral = new GameControl();
        gameContral.Player.Enable();
        gameContral.Player.Interact.performed += Interact_performed;//检测按钮按下的事件
        gameContral.Player.Operate.performed += Operate_performed;
        gameContral.Player2d.Enable();
    }

    private void Operate_performed (UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OperateHandler?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_performed (UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        InteractHandler?.Invoke(this,EventArgs.Empty);//2触发事件并将消息反馈给订阅者，
    }

    public Vector3 GetMovementDirectionNormalized ()
    {
        Vector2 dirVector2 = gameContral.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(dirVector2.x, 0, dirVector2.y).normalized;
        return direction;
    }
    public Vector3 GetMovement2dNormalized()
    {
        Vector2 dirVector2 = gameContral.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(dirVector2.x, 0, 0).normalized;
        return direction;
    }
}
