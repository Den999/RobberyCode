using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera attachedCamera;
    [SerializeField] private Transform body;

    public CinemachineVirtualCamera AttachedCamera => attachedCamera;

    public bool IsVisible
    {
        set => body.gameObject.SetActive(value);
    }
}
