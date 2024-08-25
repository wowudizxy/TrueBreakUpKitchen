using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField]private Animator _animator;
   
    public void Cut()
    {
        _animator.SetTrigger("Cut");
    }
}
