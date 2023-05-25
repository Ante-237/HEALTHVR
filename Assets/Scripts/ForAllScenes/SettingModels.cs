using UnityEngine;


namespace aptXR
{
    [CreateAssetMenu(fileName = "SettingsModel", menuName = "Settings/SettingsModel")]
    public class SettingsModels : ScriptableObject
    {
        public bool enableDynamicResolution = false;
        public float renderViewportScale = 1.0f;
        public float eyeTextureResolutionScale = 1.0f;
    }

}