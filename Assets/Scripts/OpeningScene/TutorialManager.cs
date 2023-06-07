using System;
using UnityEngine;
using UnityEngine.Video;

namespace aptXR.OpeningScene {
    public class TutorialManager : MonoBehaviour
    {

        [Header("Video Player")]
        [Tooltip("Reference to the video player for playing the tutorials videos")]
        [SerializeField]
        private VideoPlayer _VideoPlayer;

        [Header("Video Clips Tutorials To Play")]
        [SerializeField]
        public VideoClip[] _VideoClips = new VideoClip[2];


        [Header("Tutorials Controller")]
        [SerializeField] private GameObject Abutton;
        [SerializeField] private GameObject Bbutton;

        [Header("Tutorials Hands ")]
        [SerializeField] private GameObject RightHand;
        [SerializeField] private GameObject LeftHand;

        [Header("TutorialManager")]
        [SerializeField]
        private ControlsManager _ControlsManager;


        private readonly float _StartTime = 1.0f;
        private readonly float _RepeatTime = 2.0f;






        void Start ()
        {
            InvokeRepeating("VerifyControlType", _StartTime, _RepeatTime);
        }

        
        void VerifyControlType()
        {
            if(_ControlsManager != null)
            {
                if (_ControlsManager.IsHands)
                {
                    SetHandVideo();
                }
                else
                {
                    SetControllerVideo();
                }
            }
        }
        




        /// <summary>
        /// tutorioals below for what tutorials video to show or play
        /// </summary>
        void SetControllerVideo()
        {
            try
            {
                _VideoPlayer.clip = _VideoClips[0];

                switchButtonTutorial(true);
                switchHandTutorials(false);
            }
            catch (IndexOutOfRangeException)
            {
                Debug.LogWarning("The VideoClip Index has not been Assigned");
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("No Reference to Video Player");
            }
        }

        void SetHandVideo()
        {
            try
            {
                _VideoPlayer.clip = _VideoClips[1];
                switchButtonTutorial(false);
                switchHandTutorials(true);
            }
            catch (IndexOutOfRangeException)
            {
                Debug.LogWarning("The VideoClip Index has not been Assigned");
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("No Reference to Video Player");
            }
        }


        void switchButtonTutorial(bool value)
        {
            Abutton.SetActive(value);
            Bbutton.SetActive(value);
        }

        void switchHandTutorials(bool value)
        {
            RightHand.SetActive(value);
            LeftHand.SetActive(value);
        }


    }
}


