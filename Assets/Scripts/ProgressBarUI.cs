using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    private Image progressBar;
    private void Awake()
    {
        Transform progressTransform = transform.Find("Progress");
        if (progressTransform != null)
        {
            progressBar = progressTransform.GetComponent<Image>();
        }
        else
        {
            Debug.LogError("Progress child object not found!");
        }
    }

    public void Show ()
    {
        gameObject.SetActive(true);
    }
    public void Hide ()
    {
        gameObject.SetActive(false);
    }
    public void UpdateProgress (float precent)
    {
        Show ();
        progressBar.fillAmount = precent;
        if (precent == 1)
        {
            Invoke("Hide", 1);
        }
    }
}
