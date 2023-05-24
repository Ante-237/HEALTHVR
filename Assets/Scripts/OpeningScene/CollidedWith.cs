using Oculus.Interaction.Samples;
using UnityEngine;

namespace aptXR.OpeningScene
{


    public class CollidedWith : MonoBehaviour
    {
        private SceneNames sceneNames;

        private readonly string _RightBox = "RightBox";
        private readonly string _LeftBox = "LeftBox";

        public void SetSceneData(SceneNames _SceneNames)
        {
            sceneNames = _SceneNames;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_RightBox)){
                LevelManager.Instance.FadingOutAnimation();
                other.GetComponent<SceneLoader>().Load(sceneNames.AllScenes[1]);            
            }

            if (other.CompareTag(_LeftBox))
            {
                LevelManager.Instance.FadingOutAnimation();
                other.GetComponent<SceneLoader>().Load(sceneNames.AllScenes[2]);
            }
        }


     
    }
}