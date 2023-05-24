using UnityEngine;


namespace aptXR.OpeningScene
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;

        [Header("OpeningScene Information")]
        [SerializeField]
        private LevelInformation levelInformation;


        [Header("FadingAnimation Control")]
        [SerializeField]
        [Tooltip("Provide the Fading information Script Reference to control the animation Fading in and Out")]
        private FadingAnimation _fadingAnimation;



        public static LevelManager Instance
        {
            get { return instance; }
        }

        private void Start()
        {
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

        }


        // play the fading in animation when scene starts
        void FadinginAnimation()
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

        }

    }
}

