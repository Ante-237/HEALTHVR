using UnityEngine;


namespace aptXR.Microbiology
{
    public class CourseWindowAnim : MonoBehaviour
    {

        [SerializeField] private Animator animatorDetailsPanel;
        [SerializeField] private Animator animatorCoursesPanel;
        [SerializeField] private Animator animatorProfilePanel;


        private readonly int isOpen = Animator.StringToHash("isOpen");
        private readonly int isClose = Animator.StringToHash("isClose");

        private readonly int slideIn = Animator.StringToHash("slideIn");
        private readonly int slideOut = Animator.StringToHash("slideOut");



        // for the profiles panel
        public void slidePanelInProfile(bool value)
        {
            if (value)
            {
                try
                {
                    animatorProfilePanel.SetBool(slideOut, false);
                    animatorProfilePanel.SetBool(slideIn, true);

                }
                catch (System.NullReferenceException)
                {
                    Debug.LogWarning("The Animator component of the panel has not been assigned, NUll reference");
                }
            }
        }

        public void slidePanelOutProfile(bool value)
        {
            if(value)
            {
                try
                {
                    animatorProfilePanel.SetBool(slideOut, true);
                    animatorProfilePanel.SetBool(slideIn, false);

                }
                catch (System.NullReferenceException)
                {
                    Debug.LogWarning("The Animator component of the panel has not been assigned, NUll reference");
                }
            }
        }



        // For the panel containing the courses
        public void slidePanelOutCourses(bool value)
        {
            if (value)
            {
                try
                {
                    animatorCoursesPanel.SetBool(slideOut, true);
                    animatorCoursesPanel.SetBool(slideIn, false);

                }
                catch (System.NullReferenceException)
                {
                    Debug.LogWarning("The Animator component of the panel has not been assigned, NUll reference");
                }
            }
        }


        public void slidePanelInCourses(bool value)
        {
            if (value)
            {
                try
                {
                    animatorCoursesPanel.SetBool(slideOut, false);
                    animatorCoursesPanel.SetBool(slideIn, true);

                }
                catch (System.NullReferenceException)
                {
                    Debug.LogWarning("The Animator component of the panel has not been assigned, NUll reference");
                }
            }
        }







        // For details Panel when profile selected
        public void showPanel(bool value)
        {

            if (value)
            {
                try
                {
                    animatorDetailsPanel.SetBool(isOpen, true);
                    animatorDetailsPanel.SetBool(isClose, false);

                }
                catch (System.NullReferenceException)
                {
                    Debug.LogWarning("The Animator component of the panel has not been assigned, NUll reference");
                }
            }
          
        }


        public void hidePanel(bool value)
        {
            if (!value)
            {
                try
                {
                    animatorDetailsPanel.SetBool(isOpen, false);
                    animatorDetailsPanel.SetBool(isClose, true);

                }
                catch (System.NullReferenceException)
                {
                    Debug.LogWarning("The Animator component of the panel has not been assigned, NUll reference");
                }
            }
         
        }
    }

}
