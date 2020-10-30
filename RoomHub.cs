using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Utils;
using UnityEngine;

public class RoomHub : SwitchableHub<Room>
{
    [SerializeField] private Room _entryRoom;
    
    private CameraHub _cameraHub;

    private void Start()
    {
        _cameraHub = gameObject.FindOrCreate<CameraHub>();
        
        if (_entryRoom != null)
            Current = _entryRoom;
    }

    protected override void SwitchMember(Room member, bool state)
    {
        member.IsVisible = state;

        if (state)
        {
            _cameraHub.Current = member.AttachedCamera;
        }
    }
}
