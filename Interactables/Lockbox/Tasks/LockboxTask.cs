using System;
using UnityEngine;

namespace D2D
{
    public abstract class LockboxTask : MonoBehaviour
    {
        public abstract bool IsCompleted { get; }
    }
}