using Oculus.Interaction.Samples;
using System;
using UnityEngine;
using UnityEngine.Android;

namespace aptXR.OpeningScene {
    public class SelectionManager : MonoBehaviour
    {

        [Header("Scene Container")]
        [Tooltip("Holds Reference to the Scene Container that contains all the scene names")]
        [SerializeField]
        private SceneNames _SceneNames;

        [SerializeField]
        [Header("Reference ControlsManager")]
        private ControlsManager _ControlsManager;


        [Header("Fading Timeing")]
        [SerializeField]
        private float WaitTime = 1.0f;

        [Header("Controller Vibrations")]
        [SerializeField]
        private float VibrationFrequency = 0.1f;
        [SerializeField]
        private float VibrationAmplitude = 0.1f;

        // provides instance of the sceneLoader
        private SceneLoader _SceneLoader;

        private void Start()
        {
            gameObject.AddComponent<SceneLoader>();
            _SceneLoader = gameObject.GetComponent<SceneLoader>();          
        }

        private void Update()
        {
            SelectionWithController();
        }


        // decide scene to load based on buttons showing on screen and vibrate controller in the direction
        void SelectionWithController()
        {
            if (_ControlsManager.IsControllers)
            {
                if (OVRInput.Get(OVRInput.Button.One))
                {
                    OVRInput.SetControllerVibration(VibrationFrequency, VibrationAmplitude, OVRInput.Controller.RTouch);
                   
                    Invoke("LoadLoginScene", WaitTime);
                }

                if (OVRInput.Get(OVRInput.Button.Two))
                {
                    OVRInput.SetControllerVibration(VibrationFrequency, VibrationAmplitude, OVRInput.Controller.LTouch);
                  
                    Invoke("LoadTutorialScene", WaitTime);
                }
            }
        }

        // loading with poking
        public void NewUser()
        {
            Invoke("LoadTutorialScene", WaitTime);
        }

        public void oldUser()
        {

            Invoke("LoadLoginScene", WaitTime);
        }

        //Loads the login scene by referencing through the scene names
        // TODO : change to match the right scene to load
        public void LoadLoginScene()
        {
            try
            {
                LevelManager.Instance.FadingOutAnimation();
                _SceneLoader.Load(_SceneNames.AllScenes[1]);
            }
            catch (IndexOutOfRangeException)
            {
                Debug.LogWarning("The SceneName index LoginScne Has not been Assigned");
            }
           
        }

        //loads master tutorial scene
        // TODO : change to match the right scene loaded
        public void LoadTutorialScene()
        {
            try
            {
                LevelManager.Instance.FadingOutAnimation();
                _SceneLoader.Load(_SceneNames.AllScenes[2]);
            }catch(IndexOutOfRangeException)
            {
                Debug.LogWarning("The SceneName Index Tutorials Has not been Assigned");
            }
           
        }


       
    }
}

