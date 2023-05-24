
using Oculus.Interaction.Samples;
using Unity.VisualScripting;
using UnityEngine;

namespace aptXR.OpeningScene {
    public class HandCollsionBox : MonoBehaviour
    {
        [Header("Choice Colliders")]
        public GameObject RightBox;
        public GameObject LeftBox;

        [Header("Scene Names Data")]
        public SceneNames sceneNames;


        private void Start()
        {
            BoxCollider _BoxColliderRight = RightBox.GetComponent<BoxCollider>();
            _BoxColliderRight.isTrigger = true;

            BoxCollider _BoxColliderLeft = LeftBox.GetComponent<BoxCollider>();
            _BoxColliderLeft.isTrigger = true;


            _BoxColliderRight.AddComponent<CollidedWith>();
            _BoxColliderLeft.AddComponent<CollidedWith>();

            _BoxColliderRight.AddComponent<SceneLoader>();
            _BoxColliderLeft.AddComponent<SceneLoader>();

            _BoxColliderLeft.GetComponent<CollidedWith>().SetSceneData(sceneNames);
            _BoxColliderRight.GetComponent<CollidedWith>().SetSceneData(sceneNames);

        }


    }


}

