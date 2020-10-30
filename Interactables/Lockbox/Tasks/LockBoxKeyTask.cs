using System;
using UnityEngine;
using UnityEngine.VR;

namespace D2D
{
    public class LockBoxKeyTask : LockboxTask
    {
        [SerializeField] private Key _connectedKey;

        public override bool IsCompleted
        {
            get
            {
                var inventory = FindObjectOfType<Inventory>();
                
                Debug.Log(inventory);
            
                // If player found a key => complete
                var playerFoundKey = inventory.Contains(_connectedKey);
                if (playerFoundKey)
                    _connectedKey.Throw();
                return playerFoundKey;
            }
        }
    }
}