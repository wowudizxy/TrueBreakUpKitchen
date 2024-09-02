using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningControl : MonoBehaviour
{
    public const string ISWARNING = "IsWarning";
    [SerializeField] private Animator warningAnimator;
    private float WarningTimer = 0;
    private float WarningTimeMax = 0.7f;
    private bool isWarning = false;
    private void Update()
    {
        if (isWarning)
        {
            WarningTimer += Time.deltaTime;
            if(WarningTimer > WarningTimeMax)
            {
                WarningTimer = 0;
                SoundManager.Instance.WarningSound();
            }
        }
    }
    public void Show()
    {
        isWarning = true;
        gameObject.SetActive(true);
        warningAnimator.SetBool(ISWARNING, true);
        
    }
    public void Hide()
    {
        isWarning = false;
        
        warningAnimator.SetBool(ISWARNING, false);
        gameObject.SetActive(false);
    }
}
