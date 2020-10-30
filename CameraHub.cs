using Cinemachine;
using D2D;
using D2D.Utils;
using UnityEngine;

public class CameraHub : SwitchableHub<CinemachineVirtualCamera>
{
    private CinemachineVirtualCamera _temporaryCamera;
    
    protected override void SwitchMember(CinemachineVirtualCamera member, bool state)
    {
        member.Priority = state ? 100 : 0;
    }

    public void SetTempCamera(CinemachineVirtualCamera newCamera)
    {
        if (_temporaryCamera != null)
            _temporaryCamera.Priority = 0;

        _temporaryCamera = newCamera;
        _temporaryCamera.Priority = 1000;
        
        Debug.Log("Switch");
    }

    public void RemoveTempCamera(CinemachineVirtualCamera removingCamera)
    {
        removingCamera.Priority = 0;
    }
}
