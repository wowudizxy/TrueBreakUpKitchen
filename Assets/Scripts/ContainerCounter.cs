using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    private const string OPEN_CLOSE = "OpenClose";
    private Animator _animator;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private void Start ()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject()) return;
        _animator.SetTrigger(OPEN_CLOSE);
        CreateKitchenObject(kitchenObjectSO.prefab);
        TransferKitchenObject(this,player);
    }
    public void CreateKitchenObject (GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = Instantiate(kitchenObjectPrefab, GetHoldPoint(), false).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}
