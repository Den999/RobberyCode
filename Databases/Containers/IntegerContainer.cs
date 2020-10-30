using UnityEngine;

namespace D2D.Database
{
    public class IntegerContainer : ContainerBase<int>
    {
        public IntegerContainer(string key, int defaultValue) : base(key, defaultValue) { }
        
        protected override int GetValue()
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        protected override void SetValue(int newValue)
        {
            PlayerPrefs.SetInt(key, newValue);
        }
    }
}