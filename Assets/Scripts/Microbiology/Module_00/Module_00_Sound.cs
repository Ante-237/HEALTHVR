using Oculus.Interaction;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace aptXR.Microbiology.module_00
{
    public class Module_00_Sound : MonoBehaviour
    {
        private AudioTrigger audioTrigger;

        [Header("Volume Control")]
        [SerializeField]
        [Range(0f, 1f)]
        private float volume = 0.8f;

        
        [SerializeField] private AudioClip[] objectives = new AudioClip[1];
        [SerializeField] private AudioClip[] progress = new AudioClip[1];
        [SerializeField] private AudioClip[] circleGuideRead = new AudioClip[1];
        [SerializeField] private AudioClip[] circleNoCenterRead = new AudioClip[1];
        [SerializeField] private AudioClip[] CompletionRead = new AudioClip[1];

#if UNITY_EDITOR
        void NullTesting()
        {
            this.AssertCollectionField(objectives, nameof(objectives));
            this.AssertCollectionField(progress, nameof(progress));
            this.AssertCollectionField(circleGuideRead, nameof(circleGuideRead));
            this.AssertCollectionField(circleNoCenterRead, nameof(circleNoCenterRead)); 
            this.AssertCollectionField(CompletionRead, nameof(CompletionRead));
        }

        private void OnEnable()
        {
            NullTesting();
        }
#endif

        private void Start()
        {
        
            audioTrigger = gameObject.GetComponent<AudioTrigger>();
        }
        

        public void PlayObjectiveRead()
        {
            audioTrigger.InjectAudioClips(objectives);
            audioTrigger.PlayAudio();
            audioTrigger.Volume = volume;
        }


        public void PlayProgressRead()
        {
            audioTrigger.InjectAudioClips(progress);
            audioTrigger.PlayAudio();
            audioTrigger.Volume = volume;
        }

        public void PlayCircleGuideRead()
        {
            audioTrigger.InjectAudioClips(circleGuideRead);
            audioTrigger.PlayAudio();
            audioTrigger.Volume = volume;
        }

        public void PlayCircleDropGuideRead()
        {
            audioTrigger.InjectAudioClips(circleNoCenterRead);
            audioTrigger.PlayAudio();
            audioTrigger.Volume = volume;
        }

        public void PlayEndofCourse()
        {
            audioTrigger.InjectAudioClips(CompletionRead);
            audioTrigger.PlayAudio();
            audioTrigger.Volume = volume;
        }
    }
}