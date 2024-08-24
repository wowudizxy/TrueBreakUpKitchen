using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OperateHandler;
    public event EventHandler InteractHandler;//1����һ�����ڽ������¼���event �ؼ�����������һ���¼����¼��ǻ���ί�����͵ģ�������ͨί�в�ͬ���¼�ֻ�����䶨������б������������ã�����������ֻ�ܶ��ģ�+=����ȡ�����ģ�-=������¼���
    private GameControl gameContral;
    private void Start ()
    {
        gameContral = new GameControl();
        gameContral.Player.Enable();
        gameContral.Player.Interact.performed += Interact_performed;//��ⰴť���µ��¼�
        gameContral.Player.Operate.performed += Operate_performed;
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
}
