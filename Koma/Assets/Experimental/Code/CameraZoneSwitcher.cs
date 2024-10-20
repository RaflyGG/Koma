using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoneSwitcher : MonoBehaviour
{
    public string zoneTag;

    public CinemachineVirtualCamera primaryCamera;

    public CinemachineVirtualCamera[] virtualCamera;

    void Start()
    {
        SwitchToCamera(primaryCamera);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(zoneTag))
        {
            CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
            SwitchToCamera(targetCamera);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(zoneTag))
        {
            SwitchToCamera(primaryCamera);
        }
    }

    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in virtualCamera)
        {
            camera.enabled = camera == targetCamera;
        }
    }

}
