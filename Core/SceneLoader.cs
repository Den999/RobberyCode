using System;
using D2D.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace D2D.Core
{
    /// <summary>
    /// Responsible for scene loading, takes data from GameData
    /// </summary>
    public class SceneLoader : MonoBehaviour, ILazyCreating
    {
        /// <summary>
        /// Current scene name
        /// </summary>
        public static string SceneName => SceneManager.GetActiveScene().name;

        /// <summary>
        /// Used for postponed scene loading. The scene with this name will be loaded 
        /// </summary>
        private static string nextSceneName = "";

        /// <summary>
        /// Time of current scene load
        /// </summary>
        public static float TimeSinceSceneStart { get; private set; }

        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = gameObject.FindOrCreate<GameStateMachine>();
            TimeSinceSceneStart = Time.time;
        }

        public void ReloadCurrentScene(float delay = 0)
        {
            FunctionTimer.Create(() => StartSceneLoading(SceneName), delay);
        }

        public void LoadMainMenu()
        {
            StartSceneLoading(ScenesData.Instance.mainMenuSceneName);
        }

        public void LoadLevel(int levelNumber)
        {
            if (levelNumber <= 0 || levelNumber > ScenesData.Instance.levelScenesCount)
            {
                Debug.LogError("Level number out of bounds");
                return;
            }

            StartSceneLoading(ScenesData.Instance.levelScenePrefix + levelNumber);
        }

        private void StartSceneLoading(string desiredSceneName)
        {
            // Remember next scene
            nextSceneName = desiredSceneName;

            // Set PostgameState
            _gameStateMachine.PushState(new PostgameState());

            // Load scene immediately or do it after scene transition finish
            var sceneTransition = FindObjectOfType<SceneTransition>();
            if (sceneTransition == null)
            {
                FinishSceneLoading();
            }
            else
            {
                sceneTransition.Completed += FinishSceneLoading;
            }
        }

        private void FinishSceneLoading()
        {
            if (nextSceneName != "")
                SceneManager.LoadScene(nextSceneName);
        }
    }
}
