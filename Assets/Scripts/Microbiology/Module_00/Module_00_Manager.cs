using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.Samples;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

namespace aptXR.Microbiology.module_00
{

    // TODO : disable panels objectives after a certain time
    // TODO : controls instructions guide to direct the user
    // TODO : tracks the progress of all process and updates the task to be completed.
    public class Module_00_Manager : MonoBehaviour
    {
        [Header("SceneDataModel")]
        [SerializeField] private SceneNames sceneNames;

        [Header("Usage Present")]
        [SerializeField] private OVRHand RightHand;
        [SerializeField] private OVRHand LeftHand;
        private bool _userActive = false;

        [Header("Center Eye")]
        [SerializeField] private OVRCameraRig CameraRig;


        [Header("Pointer")]
        [SerializeField] private GameObject PointerPrefab;
        [SerializeField] private List<Transform> PointerPositions = new List<Transform>();
        [SerializeField] private List<string> PointerDisplays = new List<string>();
        [SerializeField] private List<bool> Tasks = new List<bool>();

        [Header("Objectives Board")]
        [SerializeField] private GameObject ObjectivesBoard;

        [Header("Update PerFrame")]
        [SerializeField] private int FrameCount = 0;
        [SerializeField] private int UpdateTime = 6;


        [Header("Time Before Objective Board Dissappears")]
        [SerializeField] private float _objectiveBoardTime = 90;



        [Header("Task Number")]
        [SerializeField] private int numberOfTasks = 10;

        [Header("Bot Reference Script")]
        [SerializeField] private module_00_bot bot;

        [Header("Module_00 Reference Script")]
        [SerializeField] private Module_00 _moduel_00;

        [Header("Reference to Bot")]
        [SerializeField] private GameObject _bot;


        private SceneLoader _sceneLoader;
        private GameObject __pointerPrefab;

        private void Start()
        {
            FirstStep();         
        }

        private void FirstStep()
        {
            UpdatePointer(PointerPositions[0].transform, PointerDisplays[0]);
            StartCoroutine(ObjectivesDisable());                
        }

        private void StepProgressBoard()
        {
            UpdatePointer(PointerPositions[1].transform, PointerDisplays[1]);
            StartCoroutine(ProgressPointerChange());
        }
        
        private void UpdatePointer(Transform __position, string __content)
        {
         
            __pointerPrefab = Instantiate(PointerPrefab, __position.position, Quaternion.identity);
            __pointerPrefab.AddComponent<LookATTArget>();
            __pointerPrefab.GetComponent<LookATTArget>()._toRotate = __pointerPrefab.transform;
            __pointerPrefab.GetComponent<LookATTArget>()._target = CameraRig.centerEyeAnchor.transform;
            // pointerPrefab.GetComponentInChildren<LookATTArget>()._target = CameraRig.centerEyeAnchor.transform;
            TextMeshPro _contentText = __pointerPrefab.transform.GetComponentInChildren<TextMeshPro>() as TextMeshPro;
            _contentText.text = __content;
        }

        IEnumerator ProgressPointerChange()
        {
            yield return new WaitForSeconds(8.0f);
            UpdateProgress(2);
            Destroy(__pointerPrefab);
            bot.SetIdleActions();
            BotStatus(false);
            Tasks[1] = true;
        }

        void BotStatus(bool value)
        {
            _bot.SetActive(value);
        }

        IEnumerator ObjectivesDisable()
        {
            yield return new WaitForSeconds(_objectiveBoardTime);

            ObjectivesBoard.SetActive(false);
            Destroy(__pointerPrefab);
            // task one done
            Tasks[0] = true;
            bot.SetMoveAway();
            UpdateProgress(5);
            StepProgressBoard(); // start next steps
        }

        private void UpdateProgress(int amount)
        {
            _moduel_00.ProgressAmount += amount;
            _moduel_00.UpdateProgressBar();
        }

        private void checkIfUserIsActive()
        {
            if (RightHand.IsTracked || LeftHand.IsTracked)
            {
                _userActive = true;
            }
        }



        public void ExitCourse()
        {
            _sceneLoader.Load(sceneNames.AllScenes[8]);
        }

        public void ShowCourseBoard()
        {
            if (ObjectivesBoard.activeInHierarchy)
            {
                ObjectivesBoard.SetActive(false);
            }
            else
            {
                ObjectivesBoard.SetActive(true);
            }
        }

        private void Update()
        {
            CustomUpdate();
        }

        private void CustomUpdate()
        {
            FrameCount++;
            if (FrameCount > UpdateTime)
            {
                FrameCount = 0;
                // call methods here that needs free updates per frame

                checkIfUserIsActive();
               
            }
        }

        private void InitializedTask()
        {
            for(int i = 0; i < numberOfTasks; i++)
            {
                Tasks[i] = false;
            }
        }


        private void Awake()
        {
           gameObject.AddComponent<SceneLoader>();
           _sceneLoader = gameObject.GetComponent<SceneLoader>();

            InitializedTask();

            //move bot
            bot.SetObjectivesActions();
        }

    }
}