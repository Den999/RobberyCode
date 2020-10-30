using System;
using UnityEngine;

namespace D2D.Database
{
    public abstract class ContainerBase<T>
    {
        public event Action<T> ValueChanged;
        
        protected T defaultValue;
        protected string key;

        public virtual T Value
        {
            get => GetValue();
            set
            {
                SetValue(value);
                ValueChanged?.Invoke(value);
            }
        }
        
        public bool IsEmpty => !PlayerPrefs.HasKey(key);

        protected ContainerBase(string key, T defaultValue)
        {
            this.key = key;
            this.defaultValue = defaultValue;
        }

        protected abstract T GetValue();

        protected abstract void SetValue(T newValue);
    }
}