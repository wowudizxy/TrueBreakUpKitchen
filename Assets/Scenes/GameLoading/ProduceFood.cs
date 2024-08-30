
using System;
using System.Collections;
using UnityEngine;

public class ProduceFood : MonoBehaviour
{
    [SerializeField] private float createFoodPos = 8f;
    [SerializeField] private CreateFoodSO foodSO;
    [SerializeField] private float createTime = 2f;

    private void Start()
    {
        StartCoroutine(CreatFoodTime(createTime, () => CreateFood()));
    }
   
    private void CreateFood()
    {
        int number = UnityEngine.Random.Range(0,foodSO.foodList.Count);
        float x = UnityEngine.Random.Range(-createFoodPos, createFoodPos);
        GameObject food = Instantiate(foodSO.foodList[number], new Vector3(x, createFoodPos, 0), Quaternion.identity);
        StartCoroutine(CreatFoodTime(createTime, () => CreateFood()));
    }
    IEnumerator CreatFoodTime(float createTime,Action action)
    {
        yield return new WaitForSeconds(createTime);
        action?.Invoke();
    }
}
