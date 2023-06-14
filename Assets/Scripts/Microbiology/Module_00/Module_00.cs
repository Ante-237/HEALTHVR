using UnityEngine;
using TMPro;
using Unity.VisualScripting;


namespace aptXR.Microbiology.module_00
{

    //TODO : loads the objective panel
    //TODO : loads the name of the course in the background
    //TODO : Update progress bar

    

    public class Module_00: MonoBehaviour
    {
        [Header("CourseData")]
        [SerializeField] private CourseContent courseData;


        [Header("ObjectivesPrefabs")]
        [SerializeField] private GameObject FullObjectiveBoard;
        [SerializeField] private GameObject AnchorAddingObjectives;
        [SerializeField] private GameObject ObjectiveAdditionTemplate;
        


        [Header("Course Name")]
        [SerializeField] private TextMeshProUGUI courseName;

        [Header("Progress Bar")]
        [SerializeField] private GameObject RootProgressBar;
        [SerializeField] private TextMeshProUGUI ProgressDisplay;


        public int ProgressAmount
        {
            set { _progressAmount = value; }
            get { return _progressAmount; }
        }
        private int _progressAmount = 0;


        


        private void Start()
        {
            LoadObjectivesPanel();
            UpdateCourseName();
            LoadProgressBar();
            
        }

        private void LoadObjectivesPanel()
        {
            FullObjectiveBoard.SetActive(true);
            AddCourseObjectives();
        }

        private void LoadProgressBar()
        {
            RootProgressBar.SetActive(true);
            UpdateProgressBar();
        }

        private void AddCourseObjectives()
        {
            for(int i = 0; i < courseData.CourseObjectives.Count; i++)
            {
                GameObject _template = Instantiate(ObjectiveAdditionTemplate, AnchorAddingObjectives.transform);
                TextMeshProUGUI _objectives = _template.transform.GetComponentInChildren<TextMeshProUGUI>();
                _objectives.text = courseData.CourseObjectives[i];

                _template.transform.SetParent(AnchorAddingObjectives.transform);
            }
        }


        private void UpdateCourseName()
        {
            courseName.text = courseData.CourseName;
        }


        public void UpdateProgressBar()
        {
            if(_progressAmount >= 0 && _progressAmount <= 100) {
                ProgressDisplay.text = _progressAmount + "%";
            }

                 
        }


        
    }
}