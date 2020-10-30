using D2D.Database;
using UnityEngine;

namespace D2D
{
    public static class LevelDatabase
    {
        private const string LevelCompletionKey = "IsLevelCompleted";
        
        private static IntegerContainer _lastLevelContainer = 
            new IntegerContainer("LastLevel", 1);
        
        private static IntegerContainer _biggestCompletedLevelContainer = 
            new IntegerContainer("BiggestCompletedLevel", 0);
        
        /// <summary>
        /// On which level player stopped?
        /// </summary>
        public static int LastLevel
        {
            get => _lastLevelContainer.Value;
            set => _lastLevelContainer.Value = value;
        }

        /// <summary>
        /// Which maximum level was completed?
        /// </summary>
        public static int BiggestCompletedLevel
        {
            get => _biggestCompletedLevelContainer.Value;
            private set => _biggestCompletedLevelContainer.Value = value;
        }

        public static bool IsLevelCompleted(int levelNumber)
        {
            return new BoolContainer(LevelCompletionKey + levelNumber, false).Value;
        }

        public static void SetLevelCompleted(int levelNumber)
        {
            new BoolContainer(LevelCompletionKey + levelNumber, false).Value = true;
            
            if (levelNumber > BiggestCompletedLevel)
                BiggestCompletedLevel = levelNumber;
        }
    }
}