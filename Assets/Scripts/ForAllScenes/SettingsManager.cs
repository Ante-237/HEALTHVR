
using UnityEngine;
using UnityEngine.XR;

namespace aptXR
{
    public class SettingsManager : MonoBehaviour
    {
        private static SettingsManager instance;

        public static SettingsManager Instance
        {
            get { return instance; }
        }

        [SerializeField]
        private SettingsModels settingsModels;


        void RenderSettings()
        {
            try
            {
                DynamicResolutionSetting();
                RenderViewPointScale();
                EyeTextureResolutionScale();
            } catch (System.NullReferenceException)
            {
                Debug.LogWarning(" SettingsModel Has Not Been Asssigned ");
            }
        }


        // main update method to be called when settings are changed. 
        public void UpdateSettings()
        {
            RenderSettings();
        }










        // handle quality settings for rendering
        void DynamicResolutionSetting()
        {
            OVRManager.instance.enableDynamicResolution = settingsModels.enableDynamicResolution;
        }

        void RenderViewPointScale()
        {
            XRSettings.renderViewportScale = settingsModels.renderViewportScale;
        }

        void EyeTextureResolutionScale()
        {
            XRSettings.eyeTextureResolutionScale = settingsModels.eyeTextureResolutionScale;
        }



        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
               
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }

}
