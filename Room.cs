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
        set
        {
            // var allMeshRenderersInRoom = GetComponentsInChildren<MeshRenderer>(); 
            // foreach (MeshRenderer meshRenderer in allMeshRenderersInRoom)
            //     meshRenderer.enabled = value;
            //
            // var allCollidersInRoom = GetComponentsInChildren<Collider>(); 
            // foreach (Collider coll in allCollidersInRoom)
            //     coll.enabled = value;
            
            body?.gameObject.SetActive(value);
        }
    }
}
