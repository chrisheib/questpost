using BepInEx;
using Wish;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace questpost
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        // private Harmony m_harmony = new Harmony("stschiff.questpost");

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            // ScenePortalManager.onLoadedScene += OnSceneLoaded;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            // this.m_harmony.PatchAll();
        }

        public void AddBoard()
        {
            Logger.LogInfo($"Scene {ScenePortalManager.ActiveSceneName} ({ScenePortalManager.ActiveSceneIndex}) loaded!");
            // Instantiate(Wish.BulletinBoard, ScenePortalManager.)
            // TODO: Instantiate with scene parent :) 
            // Set location based on activescenename
        }
        public void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Logger.LogInfo($"Scene {arg0.name}, {arg0.path} |old: {ScenePortalManager.ActiveSceneName} ({ScenePortalManager.ActiveSceneIndex}) loaded, mode {arg1}!");
            if (arg0.name == "Tier1House0")
            {
                Logger.LogInfo("house load detected!");
                ScenePortalManager.onLoadedScene += AddBoard;
            }
        }

        //[HarmonyPatch(typeof(load), "Awake")]
        //class HarmonyPatch_Pickup_Awake
        //{

        //    private static void Postfix(ref float ___radius)
        //    {
        //        if (m_enabled.Value)
        //        {
        //            ___radius = m_pickup_radius.Value;
        //        }
        //    }
        //}
    }
}
