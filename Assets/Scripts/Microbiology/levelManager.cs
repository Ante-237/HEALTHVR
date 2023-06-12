using Oculus.Interaction.Samples;
using Unity.VisualScripting;
using UnityEngine;


namespace aptXR.Microbiology
{
    public class levelManager: MonoBehaviour
    {
        [Header("Scenes Data Model")]
        [SerializeField] private SceneNames sceneNames;




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

    }
}