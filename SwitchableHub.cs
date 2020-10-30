using UnityEngine;

namespace D2D
{
    public abstract class SwitchableHub<T> : HubBase<T>
        where T: Component
    {
        private T _current;
        
        public T Current
        {
            get => _current;
            set
            {
                DisableAllMembers();
                
                SwitchMember(value, true);
                _current = value;
            }
        }

        private void DisableAllMembers()
        {
            foreach (T member in Members)
                SwitchMember(member, false);
        }

        protected abstract void SwitchMember(T member, bool state);
    }
}