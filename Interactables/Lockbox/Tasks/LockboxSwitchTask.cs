using UnityEngine;

namespace D2D
{
    public class LockboxSwitchTask : LockboxTask
    {
        [SerializeField] private Switch _connectedSwitch;
        
        public override bool IsCompleted => _connectedSwitch.State;
    }
}