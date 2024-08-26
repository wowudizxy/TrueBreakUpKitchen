using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
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

    private void Update()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                transform.LookAt(transform.position - Camera.main.transform.position + transform.position);
                break;
            case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraBackward:
                transform.forward = -Camera.main.transform.forward;
                break;
            case Mode.WorldForward:
                transform.forward = new Vector3(0, 0, 1);
                break;
            case Mode.WorldBackward:
                transform.forward = new Vector3(0, 0, -1);
                break;
            default:
                break;
        }

    }
}
