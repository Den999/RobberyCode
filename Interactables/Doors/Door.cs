using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Utils;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private Room _nextRoom;
    [SerializeField] private Transform _nextPlayerPoint;

    public event Action Opened;

    protected override void OnAction()
    {
        var hub = gameObject.FindOrCreate<RoomHub>().Current = _nextRoom;
        FindObjectOfType<Player>().transform.position = _nextPlayerPoint.position;
        
        Opened?.Invoke();
    }
}
