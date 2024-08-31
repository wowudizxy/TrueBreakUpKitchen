using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStaticData : MonoBehaviour
{
    private void Start()
    {
        CuttingCounter.ClearStaticData();
        TrashCounter.ClearStaticData();
        PlayerSound.ClearStaticData();
        KitchenObjectHolder.ClearStaticData();

    }
}
