using System;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace aptXR.OpeningScene
{
    public class SceneBuilder : MonoBehaviour
    {

        [Serializable]
        public class AssetReferenceMaterial : AssetReferenceT<Material>
        {
            public AssetReferenceMaterial(string guid) : base(guid) { }
        }


        public AssetReferenceGameObject RightObject;
        public AssetReferenceGameObject LeftObject;
        public AssetReferenceGameObject FloorObject;


        public AssetReferenceMaterial RightMaterial;
        public AssetReferenceMaterial LeftMaterial;
        public AssetReferenceMaterial FloorMaterial;


        public Vector3 RightPosition;
        public Vector3 LeftPosition;
        public Vector3 FloorPosition;

        [Header("Mesh Masterials ")]
        MeshRenderer RightObject_Renderer;
        MeshRenderer LeftObject_Renderer;
        MeshRenderer FloorObject_Renderer;

        [SerializeField]
        private int TimeBeforeIntance = 10;


        int CounterBetween = 0;
        bool FirstRun = true;

        private void Start()
        {
            LoadObjectAssetReferences();
        }

        void LoadObjectAssetReferences()
        {
            RightObject.LoadAssetAsync();
            LeftObject.LoadAssetAsync();
            FloorObject.LoadAssetAsync();
            FloorMaterial.LoadAssetAsync();
            LeftMaterial.LoadAssetAsync();
            FloorMaterial.LoadAssetAsync();
        }

        private void FixedUpdate()
        {
            BuildScene();
        }


        /// <summary>
        /// Loads the Content of the scene and instantiates them in the right position while assigning the materials
        /// Load only after a certain number of frames. 
        /// </summary>
        void BuildScene()
        {
            if(FirstRun)
            {
                CounterBetween++;
            }

            if(CounterBetween == TimeBeforeIntance)
            {
                if (RightObject != null)
                {

                    GameObject rightObject = Instantiate(RightObject.Asset, RightPosition, Quaternion.identity) as GameObject;
                    RightObject_Renderer = rightObject.GetComponent<MeshRenderer>();
                    if(RightMaterial != null)
                    {
                        RightObject_Renderer.material = RightMaterial.Asset as Material;
                    }
                }

                if(LeftObject != null)
                {
                    GameObject leftObject = Instantiate(LeftObject.Asset, LeftPosition, Quaternion.identity) as GameObject;
                    LeftObject_Renderer = leftObject.GetComponent<MeshRenderer>();
                    if(LeftMaterial != null)
                    {
                        LeftObject_Renderer.material = LeftMaterial.Asset as Material;
                    }
                }

                if(FloorObject != null)
                {
                    GameObject floorObject = Instantiate(FloorObject.Asset, FloorPosition, Quaternion.identity) as GameObject;
                    FloorObject_Renderer = floorObject?.GetComponent<MeshRenderer>();

                    if(FloorMaterial != null && FloorObject_Renderer != null)
                    {
                        FloorObject_Renderer.material = FloorMaterial.Asset as Material;
                    }
                }

                FirstRun = false;
            }
         
        }


        private void OnDisable()
        {
            RightObject.ReleaseAsset();
            LeftObject.ReleaseAsset();
            FloorObject.ReleaseAsset();
            RightMaterial.ReleaseAsset();
            LeftMaterial.ReleaseAsset();
            FloorMaterial.ReleaseAsset();
        }

    }

}
