using Oculus.Interaction.Samples;
using Unity.VisualScripting;
using UnityEngine;


namespace aptXR.Microbiology
{
    public class levelManager: MonoBehaviour
    {
        [Header("Scenes Data Model")]
        [SerializeField] private SceneNames sceneNames;


        public float frequencyVibrat = 0.09f;
        public float amplitudeVibrat =  0.01f;

        private SceneLoader sceneLoader;




        private void Start()
        {
            gameObject.AddComponent<SceneLoader>();
            sceneLoader = gameObject.GetComponent<SceneLoader>();
        }



        public void LoadMasterMenu()
        {
            sceneLoader.Load(sceneNames.AllScenes[1]);
        }


        // send little vibration
        public void slideHaptic()
        {
          //  OVRInput.SetControllerVibration(frequencyVibrat, amplitudeVibrat, OVRInput.Controller.Active);
           
        }

    }
}