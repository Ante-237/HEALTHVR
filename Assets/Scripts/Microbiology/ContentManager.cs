using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Oculus.Interaction.Samples;

namespace aptXR.Microbiology
{

    public class ContentManager: MonoBehaviour
    {
        [Header("Course Contents")]
        [SerializeField] private CourseContent[] courseContents = new CourseContent[21];

        [Header("Course Toggles")]
        [SerializeField] private Toggle[] courseToggles = new Toggle[21];


        [Header("Selector Toggles")]
        [SerializeField] private Toggle[] selectorToggles = new Toggle[2];


        [Header("Locked Icons")]
        [SerializeField] private Image[] dimImages  = new Image[21];
        [SerializeField] private Image[] LockImages = new Image[21];



        [Header("Select Panel")]
        [SerializeField] private TextMeshProUGUI CourseName;
        [SerializeField] private TextMeshProUGUI CourseDuration;
        [SerializeField] private Button HandsUsage;
        [SerializeField] private Button Controller;
        [SerializeField] private Button StartCourse;

        [Header("AnimationScript")]
        [SerializeField] private CourseWindowAnim coursePanel;


        private SceneLoader sceneLoader;
       


        private void OnEnable()
        {
            courseToggles[0].onValueChanged.AddListener(checkSelectedCourse);
            courseToggles[0].onValueChanged.AddListener(coursePanel.showPanel);
            courseToggles[0].onValueChanged.AddListener(coursePanel.hidePanel);
            //ListenerSelectorComponents();

            // button panel
            StartCourse.onClick.AddListener(loadCourseSelected);
        }

        private void ListenerSelectorComponents()
        {
            selectorToggles[0].onValueChanged.AddListener(coursePanel.slidePanelInCourses);
            selectorToggles[0].onValueChanged.AddListener(coursePanel.slidePanelOutProfile);


            selectorToggles[1].onValueChanged.AddListener(coursePanel.slidePanelInProfile);
            selectorToggles[1].onValueChanged.AddListener(coursePanel.slidePanelOutCourses);
            
        }

        private void Start()
        {
            
            gameObject.AddComponent<SceneLoader>();
            sceneLoader = gameObject.GetComponent<SceneLoader>();


            SceneSetupCourses();
        }


        //TODO : Enabled courses only
        private void SceneSetupCourses()
        {
            if (courseContents[0].isOpen)
            {
                dimImages[0].enabled = false;
                LockImages[0].enabled = false;
            }

        }

        //TODO : do for multiple toggle manipulation
        private void checkSelectedCourse(bool value)
        {
            if (value)
            {
                CourseName.text = courseContents[0].CourseName;
                CourseDuration.text = courseContents[0].courseDuration.ToString() + " minutes";


                if (courseContents[0].needControllers) {
                    courseContents[0].needControllers = true;
                }
                else
                {
                    courseContents[0].needControllers = false;
                }


                if (courseContents[0].needHands)
                {
                    courseContents[0].needHands = true;
                }
                else
                {
                    courseContents[0].needHands = false;
                }

            }          
        }

        //TODO : load the scene for the specified course
        private void loadCourseSelected()
        {
            if (courseContents[0].isOpen)
            {
                sceneLoader.Load(courseContents[0].SceneName);
            }
        }


        private void RemoveListenerSelector()
        {
            selectorToggles[0].onValueChanged.RemoveListener(coursePanel.slidePanelInCourses);
            selectorToggles[0].onValueChanged.RemoveListener(coursePanel.slidePanelOutProfile);


            selectorToggles[1].onValueChanged.RemoveListener(coursePanel.slidePanelInProfile);
            selectorToggles[1].onValueChanged.RemoveListener(coursePanel.slidePanelOutCourses);
        }

        private void OnDisable()
        {
            courseToggles[0].onValueChanged.RemoveListener(checkSelectedCourse);
            courseToggles[0].onValueChanged.RemoveListener(coursePanel.showPanel);
            courseToggles[0].onValueChanged.RemoveListener(coursePanel.hidePanel);
            StartCourse.onClick.RemoveListener(loadCourseSelected);

           // RemoveListenerSelector();

        }

    }
}