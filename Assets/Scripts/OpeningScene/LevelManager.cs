using JetBrains.Annotations;
using Oculus.Interaction;
using System.Collections.Generic;
using UnityEngine;


namespace aptXR.OpeningScene
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;

        [Header("OpeningScene Information")]
        [SerializeField]
        private LevelInformation levelInformation;

        [Header("VirtualTags")]
        [SerializeField]
        private VirtualTagModels _VirtualTagsModel;


        [Header("Level Audio")]
        [SerializeField]
        private AudioClip[] OpeningLevelAudio = new AudioClip[2];


        [Header("FadingAnimation Control")]
        [Tooltip("Provide the Fading information Script Reference to control the animation Fading in and Out")]
        [SerializeField]
        private FadingAnimation _fadingAnimation;


        private AudioTrigger _AudioTrigger;

        public static LevelManager Instance
        {
            get { return instance; }
        }

        private void Start()
        {
            // add audio trigger
            MusicHandle();

            

            // set the Data information for first level usage   
            levelInformation.Usage += 1;     
            SetupUsage();

            // run the fade animation on scene loaded
            _fadingAnimation.FadeAnimationIn();
        }

        // call setup if only the app opened for the first time.
        private void SetupUsage()
        {
            if(levelInformation.FirstTime )
            {
                levelInformation.FirstTime = false;
            }
        }


        // play the music to play when scene starts
        void MusicHandle()
        {
            gameObject.AddComponent<AudioSource>();
            _AudioTrigger = gameObject.AddComponent<AudioTrigger>().GetComponent<AudioTrigger>();
            _AudioTrigger.InjectAudioSource(GetComponent<AudioSource>());
            _AudioTrigger.InjectAudioClips(OpeningLevelAudio);
            _AudioTrigger.InjectOptionalPlayOnStart(true);
            _AudioTrigger.Loop = true;
        }


        // play the fading in animation when scene starts
        public void FadingOutAnimation()
        {
            _fadingAnimation.FadeAnimationOut();
        }



        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }


            // saves all data from level information
            initialSave();

        }


        public void initialSave()
        {
            OpenSceneDataReadWrite dataReadWrite = new OpenSceneDataReadWrite();
            dataReadWrite.LevelInformation = levelInformation;
            dataReadWrite.VirtualTagModels = _VirtualTagsModel;
            dataReadWrite.SaveData();


        }
    }
}

