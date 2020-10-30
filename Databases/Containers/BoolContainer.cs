using UnityEngine;

namespace D2D.Database
{
    public class BoolContainer
    {
        private bool defaultValue;
        private string key;

        public bool Value
        {
            get => PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1 ? true : false;
            set => PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public BoolContainer(string key, bool defaultValue)
        {
            this.key = key;
            this.defaultValue = defaultValue;
        }
    }
}