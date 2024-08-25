using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";
    [SerializeField]private Animator _animator;
    public void Open()
    {
        _animator.SetTrigger(OPEN_CLOSE);
    }
}
