using UnityEngine;

namespace D2D.Database
{
    public class FloatContainer : ContainerBase<float>
    {
        public FloatContainer(string key, float defaultValue) : base(key, defaultValue) { }
        
        protected override float GetValue() => PlayerPrefs.GetFloat(key, defaultValue);

        protected override void SetValue(float newValue) => PlayerPrefs.SetFloat(key, newValue);
    }
}