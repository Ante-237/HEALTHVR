using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics.CodeAnalysis;
using Oculus.Interaction.Samples;
using Unity.VisualScripting;
using System.Collections;
using System.Threading;

namespace aptXR.LearningPathController
{
    public class LevelManager: MonoBehaviour
    {
        [Header("Scenes DataModel")]
        [SerializeField] private SceneNames sceneNames;

        [Header("Keys DataModel")]
        [SerializeField] private DataModelLearning keysModels;


        [Header("Text Fields")]
        [SerializeField] private TextMeshProUGUI[] firstText = new TextMeshProUGUI[4];
  

        [Header("Sprite Fields")]
        [SerializeField] private Image[] firstSprite = new Image[4];

        [Header("Used Sprites")]
        [SerializeField] private Sprite Completed;
        [SerializeField] private Sprite Uncompleted;


        private bool isPressed = false;
        private bool canLoadNextScene = false;


        private SceneLoader sceneLoader;


        private void Start()
        {
            defaultSceneLoad();
            gameObject.AddComponent<SceneLoader>(); 
            sceneLoader = gameObject.GetComponent<SceneLoader>();
        }


        private void Update()
        {
            
            checkLefthandTrigger();
            checkRightHandIndexTrigger();
            checkLeftHandIndexTrigger();
            checkRightHandTrigger();
            checkIfTutorialComplete();


            SceneControl();
        }

   
        void checkRightHandIndexTrigger()
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.8f)
            {
                if (keysModels.TimesPressed[0] < 5 && !isPressed)
                {

                    StartCoroutine(addValueScore(0));
                }
                updateUI();
            }
        }

        void checkRightHandTrigger()
        {

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.8f)
            {
                if (keysModels.TimesPressed[1] < 5 && !isPressed)
                {
                    StartCoroutine(addValueScore(1));
                }
                updateUI();
            }



        }


        void checkLeftHandIndexTrigger()
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.8f)
            {
                if (keysModels.TimesPressed[2] < 5 && !isPressed)
                {
                    StartCoroutine(addValueScore(2));
                }

                updateUI();
            }
        }

        void checkLefthandTrigger()
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.8f)
            {
                if (keysModels.TimesPressed[3] < 5 && !isPressed)
                {                
                    StartCoroutine(addValueScore(3));
                }
                updateUI();
            }
        }

        void SceneControl()
        {
            if (OVRInput.Get(OVRInput.Button.One))
            {
                LoadNextScene();
            }

             if (OVRInput.Get(OVRInput.Button.Two))
             {
                LoadPreviousScene();
             }

            
        }

        // TODO : fit in the right scene name
        public void LoadNextScene()
        {
            if(canLoadNextScene)
            {
                sceneLoader.Load(sceneNames.AllScenes[4]);
            }
            
        }

        public void LoadPreviousScene()
        {
            sceneLoader.Load(sceneNames.AllScenes[2]);
        }

        
        void defaultSceneLoad()
        {
            for(int i = 0; i < keysModels.TimesPressed.Length; i++) 
            {
                keysModels.TimesPressed[i] = 0;      
            }
        }



        void updateUI()
        {
            for (int i = 0; i < keysModels.TimesPressed.Length; i++) {
                if (keysModels.TimesPressed[i] <= 5)
                {
                    firstText[i].text = keysModels.TimesPressed[i].ToString() + "/5";
                }

                if (keysModels.TimesPressed[i] == 5)
                {
                    firstSprite[i].sprite = Completed;
                }
                  
                
            }
        }


        private IEnumerator addValueScore(int index)
        {
            isPressed = true;
            keysModels.TimesPressed[index] += 1;
            yield return new WaitForSeconds(0.3f);
            isPressed = false;
        }


        void checkIfTutorialComplete()
        {
            for(int i  = 0; i < keysModels.TimesPressed.Length;i++)
            {
                if (keysModels.TimesPressed[i] == 5)
                {
                    canLoadNextScene = true;
                    continue;

                }
                else
                {
                    canLoadNextScene = false;
                    break;
                }

             
            }
        }
    }
}