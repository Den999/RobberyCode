using UnityEditor;
using UnityEngine;
using D2D.Utils;

namespace D2D.Core
{
    /// <summary>
    /// Contains all system game data.
    /// A bit a lot of responsibilities you might say, but creating data class
    /// for every single system it is not so handful too
    /// </summary>
    [CreateAssetMenu(fileName = "ScenesData", menuName = "SO/ScenesData")]
    public class ScenesData : SingletonData<ScenesData>
    {
        public string mainMenuSceneName = "MainMenu";
        public string levelScenePrefix = "Level_";
        public int levelScenesCount = 1;
    }
}