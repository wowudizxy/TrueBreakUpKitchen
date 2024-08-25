using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    private float timer;
    private List<KitchenObject> platesList;
    [SerializeField] private int platesMax = 5;
    [SerializeField] private float span = 3;
    [SerializeField] private KitchenObjectSO plateSO;
    public override void Interact(Player player)
    {
        
    }
    private void Start()
    {
        platesList = new List<KitchenObject>();
    }
    private void Update()
    {
        if (platesList.Count < platesMax)
        {
            timer += Time.deltaTime;
            if(timer > span)
            {
                CreatePlate(plateSO);
            }
        }
    }
    public void CreatePlate(KitchenObjectSO plateSO)
    {
        timer = 0;
        Vector3 spawnPosition = GetHoldPoint().position+ Vector3.up * 0.1f * platesList.Count;
        KitchenObject kitchenObject = Instantiate(plateSO.prefab, spawnPosition, Quaternion.identity).GetComponent<KitchenObject>();
        platesList.Add(kitchenObject);
    }
}
