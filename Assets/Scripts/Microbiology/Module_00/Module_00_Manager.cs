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


        [Header("DropPointer")]
        [SerializeField] private GameObject DropPointerPrefab;
        [SerializeField] private List<Transform> DropPointerPositions = new List<Transform>();
        [SerializeField] private List<string> DropPointerDisplays = new List<string>();
        [SerializeField] private List<bool> DropTasks = new List<bool> ();

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

        [Header("Sound Control Reference")]
        [SerializeField] private Module_00_Sound _sound_Module;


        private SceneLoader _sceneLoader;
        private GameObject __pointerPrefab;
        private GameObject __dropPointerPrefab;
#if UNITY_EDITOR
        private void NullTesting()
        {
            
            this.AssertCollectionField(DropPointerPositions, nameof(DropPointerPositions));
            this.AssertCollectionField(DropPointerDisplays, nameof(DropPointerPositions));
            this.AssertCollectionField(DropTasks, nameof(DropTasks));
            this.AssertCollectionField(PointerPositions, nameof(PointerPositions));
            this.AssertCollectionField(PointerDisplays, nameof(PointerDisplays));
            this.AssertCollectionField(Tasks, nameof(Tasks));

            this.AssertField(_bot, nameof(_bot));
            this.AssertField(_moduel_00, nameof(_moduel_00));
            this.AssertField(_sound_Module, nameof(_sound_Module));
            this.AssertField(RightHand, nameof(RightHand));
            this.AssertField(LeftHand, nameof(LeftHand));
            this.AssertField(PointerPrefab, nameof(PointerPrefab));
            this.AssertField(DropPointerPrefab, nameof(DropPointerPrefab));
        }

        private void OnEnable()
        {
            NullTesting();
        }
#endif

        private void Start()
        {
            FirstStep();         
        }

        private void FirstStep()
        {
            UpdatePointer(PointerPositions[0].transform, PointerDisplays[0]);
            StartCoroutine(ObjectivesDisable());
            Invoke("playCircleGuideSound", 5.0f);
            Invoke("playReadObjectiveSound", 20.0f);
        }

        private void StepProgressBoard()
        {
            UpdatePointer(PointerPositions[1].transform, PointerDisplays[1]);
            Invoke("playProgressGuideSound", 5.0f);
            StartCoroutine(ProgressPointerChange());
        }

        // first tutorial for drop pointer
        private void DroppingIndicator()
        {
            UpdateDropPointer(DropPointerPositions[0].transform, DropPointerDisplays[0]);
            Invoke("playCircleCenterSound", 5.0f);
            StartCoroutine(DropPointerDisable());

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

        private void UpdateDropPointer(Transform __position , string __content)
        {
           __dropPointerPrefab = Instantiate(DropPointerPrefab, __position.position, Quaternion.identity);
            __dropPointerPrefab.AddComponent<LookATTArget>();
            __dropPointerPrefab.GetComponent<LookATTArget>()._toRotate = __dropPointerPrefab.transform;
            __dropPointerPrefab.GetComponent<LookATTArget>()._target = CameraRig.centerEyeAnchor.transform;
            TextMeshPro _contentText = __dropPointerPrefab.transform.GetComponentInChildren<TextMeshPro>() as TextMeshPro;
            _contentText.text = __content;
        }

        IEnumerator DropPointerDisable()
        {
            yield return new WaitForSeconds(10.0f);
            Destroy(__dropPointerPrefab);
            // task one drop pointe done
            DropTasks[0] = true;
            UpdateProgress(3);

        }

        IEnumerator ProgressPointerChange()
        {
            yield return new WaitForSeconds(12.0f);
            UpdateProgress(2);
            Destroy(__pointerPrefab);
            bot.SetIdleActions();
            BotStatus(false);
            Tasks[1] = true;
            DroppingIndicator();
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
        void BotStatus(bool value)
        {
            _bot.SetActive(value);
        }

        /* event for side menu */
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
            for(int i = 0; i < Tasks.Count; i++)
            {
                Tasks[i] = false;
            }

            for(int i = 0; i < DropTasks.Count; i++)
            {
                DropTasks[i] = false;
            }
        }


        /* Handles the playing of sounds */
        public void playReadObjectiveSound()
        {
            _sound_Module.PlayObjectiveRead();
        }

        public void playCircleGuideSound()
        {
            _sound_Module.PlayCircleGuideRead();
        }

        public void playProgressGuideSound()
        {
            _sound_Module.PlayProgressRead();
        }

        public void playCircleCenterSound()
        {
            _sound_Module.PlayCircleDropGuideRead();
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