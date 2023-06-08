using Oculus.Interaction.Samples;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace aptXR.LearningPathPick
{
    public class LevelManager: MonoBehaviour
    {
        [Header("Data Model Container")]
        [SerializeField] private DataModelLearning dataModel;

        [Header("Data Model Scenes")]
        [SerializeField] private SceneNames sceneNames;


        [Header("Text Holders")]
        [SerializeField] private TextMeshProUGUI[] TextHolders = new TextMeshProUGUI[4];

        [Header("Image Holders")]
        [SerializeField] private Image[] ImageHolders = new Image[4];

        [Header("Sprite")]
        [SerializeField] private Sprite completed;


        private SceneLoader sceneLoader;
        private bool canLoadNextScene = false;


        private void Start()
        {
            defaultState();
            gameObject.AddComponent<SceneLoader>();
            addSceneLoader();
        }

        private void Update()
        {
            NextScene();
            PreviousScene();
        }


        public void ButtonPressNormal()
        {
            if (dataModel.TimePickedController[2] < 3)
            {
                dataModel.TimePickedController[2] += 1;
            }
            updateUI();
        }


        public void ButtonPressedDeep()
        {
            if (dataModel.TimePickedController[3] < 3)
            {
                dataModel.TimePickedController[3] += 1;
            }
            updateUI();
        }


        public void PickUP()
        {
            if (dataModel.TimePickedController[0] < 3)
            {
                dataModel.TimePickedController[0] += 1;
            }
            updateUI() ;
        }


        public void DropDown()
        {
            if (dataModel.TimePickedController[1] < 3)
            {
                dataModel.TimePickedController[1] += 1;
            }
            updateUI();
        }

        void updateUI()
        {
            for(int i = 0; i < dataModel.TimePickedController.Length; i++)
            {
                if (dataModel.TimePickedController[i] <= 3)
                {
                    TextHolders[i].text = dataModel.TimePickedController[i].ToString() + "/3";
                }
               

                if (dataModel.TimePickedController[i] == 3)
                {
                    ImageHolders[i].sprite = completed;
                }
                    
                
            }
        }



        void defaultState()
        {
            for(int i = 0; i < dataModel.TimePickedController.Length; i++)
            {
                dataModel.TimePickedController[i] = 0;
            }
        }

        void addSceneLoader()
        {
            sceneLoader = gameObject.GetComponent<SceneLoader>();
        }

        // TODO : Should load the previous scene
        void PreviousScene()
        {
            if (OVRInput.Get(OVRInput.Button.Two))
            {
                sceneLoader.Load(sceneNames.AllScenes[3]);
            }
        }


        // TODO : Add the right scene to be loaded
        void NextScene()
        { 
            if (OVRInput.Get(OVRInput.Button.One))
            {
                for(int i = 0; i < dataModel.TimePickedController.Length; i++)
                {
                    if (dataModel.TimePickedController[i] == 3)
                    {
                        canLoadNextScene = true;
                        continue;
                    }
                    else
                    {
                        canLoadNextScene = false;
                    }
                }

                if (canLoadNextScene)
                {
                    sceneLoader.Load(sceneNames.AllScenes[5]);
                }
            }
        }     
    }
}