using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    public event EventHandler PauseHandler;
    public event EventHandler OperateHandler;
    public event EventHandler InteractHandler;//1����һ�����ڽ������¼���event �ؼ�����������һ���¼����¼��ǻ���ί�����͵ģ�������ͨί�в�ͬ���¼�ֻ�����䶨������б������������ã�����������ֻ�ܶ��ģ�+=����ȡ�����ģ�-=������¼���
    private GameControl gameContral;
    public enum BindingType
    {
        Up, Down, Left, Right,Interact,Operate,Pause
    }
    private void Awake()
    {
        Instance = this;
        gameContral = new GameControl();
        gameContral.Player.Enable();
        gameContral.Player.Interact.performed += Interact_performed;//��ⰴť���µ��¼�
        gameContral.Player.Operate.performed += Operate_performed;
        gameContral.Player.Pause.performed += Pause_performed;
        gameContral.Player2d.Enable();
    }
    private void Start ()
    {
        
    }
    private void OnDestroy()
    {
        gameContral.Player.Interact.performed -= Interact_performed;//��ⰴť���µ��¼�
        gameContral.Player.Operate.performed -= Operate_performed;
        gameContral.Player.Pause.performed -= Pause_performed;
        gameContral.Dispose();
    }
    public void ReBinding(BindingType bindingType)
    {
        gameContral.Player.Disable();
        InputAction inputAction = null;
        int index = -1;
        switch (bindingType)
        {
            case BindingType.Up:
                index = 1;
                inputAction = gameContral.Player.Move;
                break;
            case BindingType.Down:
                index = 2;
                inputAction = gameContral.Player.Move;
                break;
            case BindingType.Left:
                index = 3;
                inputAction = gameContral.Player.Move;
                break;
            case BindingType.Right:
                index = 4;
                inputAction = gameContral.Player.Move;
                break;
            case BindingType.Interact:
                index = 0;
                inputAction = gameContral.Player.Interact;
                break;
            case BindingType.Operate:
                index = 0;
                inputAction = gameContral.Player.Operate;
                break;
            case BindingType.Pause:
                index = 0;
                inputAction = gameContral.Player.Pause;
                break;
            default:
                break;
        }
        inputAction.PerformInteractiveRebinding(index).OnComplete(CallBack =>
        {
            CallBack.Dispose();
            gameContral.Player.Enable();
        }).Start();
    }
    public string GetBindingType(BindingType bindingType)
    {
        string temp = "";
        switch (bindingType)
        {
            case BindingType.Up:
                temp = gameContral.Player.Move.bindings[1].ToDisplayString();
                break;
            case BindingType.Down:
                temp = gameContral.Player.Move.bindings[2].ToDisplayString();
                break;
            case BindingType.Left:
                temp = gameContral.Player.Move.bindings[3].ToDisplayString();
                break;
            case BindingType.Right:
                temp = gameContral.Player.Move.bindings[4].ToDisplayString();
                break;
            case BindingType.Interact:
                temp = gameContral.Player.Interact.bindings[0].ToDisplayString();
                break;
            case BindingType.Operate:
                temp = gameContral.Player.Operate.bindings[0].ToDisplayString();
                break;
            case BindingType.Pause:
                temp = gameContral.Player.Pause.bindings[0].ToDisplayString();
                break;
            default:
                break;
        }
        return temp;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        print("Pause_performed");
        PauseHandler?.Invoke(this, EventArgs.Empty);
    }

    private void Operate_performed (UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

        OperateHandler?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_performed (UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        InteractHandler?.Invoke(this,EventArgs.Empty);//2�����¼�������Ϣ�����������ߣ�
    }

    public Vector3 GetMovementDirectionNormalized ()
    {
        Vector2 dirVector2 = gameContral.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(dirVector2.x, 0, dirVector2.y).normalized;
        return direction;
    }
    public Vector3 GetMovement2dNormalized()
    {
        Vector2 dirVector2 = gameContral.Player2d.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(dirVector2.x, 0, 0).normalized;
        return direction;
    }
}
