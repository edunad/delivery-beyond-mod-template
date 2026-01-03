using System;
using BepInEx;
using BepInEx.Logging;
using HyenaQuest;
using UnityEngine.SceneManagement;

namespace com.hyena_quest.mod_template
{
    [BepInPlugin("com.hyena-quest.mod-template", "MyPlugin", "0.0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            Logger = base.Logger;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "INGAME") return;
            Logger.LogInfo($"Running as server? {NETController.Instance.IsServer}");
        }
        
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}