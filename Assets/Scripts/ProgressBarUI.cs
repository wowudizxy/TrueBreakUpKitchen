using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    public enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraBackward,
        WorldForward,
        WorldBackward
    }
    [SerializeField] private Mode mode;
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
    private void Update()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                transform.LookAt(transform.position-Camera.main.transform.position+transform.position);
                break;
            case Mode.CameraForward:
                transform.forward=Camera.main.transform.forward;
                break;
            case Mode.CameraBackward:
                transform.forward =-Camera.main.transform.forward;
                break;
            case Mode.WorldForward:
                transform.forward =new Vector3(0,0,1);
                break;
            case Mode.WorldBackward:
                transform.forward = new Vector3(0, 0, -1);
                break;
            default:
                break;
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
        if (progressBar.fillAmount == 1)
        {
            Invoke("Hide", 1);
        }
    }
    public void SetColor(Color color)
    {
        progressBar.color = color;
    }
}
