using Oculus.Interaction.Samples;
using UnityEngine;
using UnityEngine.UI;

namespace aptXR.LearningPath
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Toggles")]
        [SerializeField] private Toggle controllerToggle;
        [SerializeField] private Toggle handsToggle;


        [Header("Panels To Show")]
        [SerializeField] private GameObject controllerPanel;
        [SerializeField] private GameObject handsPanel;

        [Header("Scene Names")]
        [SerializeField] private SceneNames sceneNames;


        private SceneLoader loader;

        private void Update()
        {
            if (OVRInput.Get(OVRInput.Button.One))
            {
                LoadNextLevel();
               // OVRInput.SetControllerVibration(0.2f, 0.1f, OVRInput.Controller.RTouch);
            }
        }
        

        private void Start()
        {
            controllerToggle.onValueChanged.AddListener(ForControllers);
            handsToggle.onValueChanged.AddListener(ForHands);

            gameObject.AddComponent<SceneLoader>();
        }

        // TODO : show controller usage instructions
        public void ForControllers(bool value)
        {
            if(controllerToggle.isOn)
            {
                controllerPanel.SetActive(true);
                handsPanel.SetActive(false);
            }
        }

        // TODO : show controller usage for hands
        public void ForHands(bool value)
        {
            if (handsToggle.isOn)
            {
                handsPanel.SetActive(true);
                controllerPanel.SetActive(false);
            }
        }

        // TODO : link to the right scene to be loaded in the game
        public void LoadNextLevel()
        {
            loader = gameObject.GetComponent<SceneLoader>();
            loader.Load(sceneNames.AllScenes[3]);
        }






        private void OnDisable()
        {
            controllerToggle?.onValueChanged.RemoveListener(ForControllers);
            handsToggle?.onValueChanged.RemoveListener(ForHands);
        }

    }
}
