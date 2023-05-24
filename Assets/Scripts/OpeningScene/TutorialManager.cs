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

        void SetControllerVideo()
        {
            try
            {
                _VideoPlayer.clip = _VideoClips[0];
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


    }
}


