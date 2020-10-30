using D2D.Utils;
using UnityEngine;

namespace D2D
{
    public class HubBase<T> : MonoBehaviour, ILazyCreating
        where T: Component
    {
        protected T[] Members { get; private set; }
        
        private void Awake()
        {
            Members = FindObjectsOfType<T>();
            OnAwake();
        }

        protected virtual void OnAwake() { }
    }
}