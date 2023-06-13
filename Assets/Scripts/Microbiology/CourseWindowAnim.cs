
using System.Threading;
using UnityEngine;

namespace aptXR.Microbiology
{
    public class CourseWindowAnim : MonoBehaviour
    {

        [SerializeField] private Animator animator;


        private readonly int isOpen = Animator.StringToHash("isOpen");
        private readonly int isClose = Animator.StringToHash("isClose");


        public void showPanel(bool value)
        {

            if (value)
            {
                try
                {
                    animator.SetBool(isOpen, true);
                    animator.SetBool(isClose, false);

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
                    animator.SetBool(isOpen, false);
                    animator.SetBool(isClose, true);

                }
                catch (System.NullReferenceException)
                {
                    Debug.LogWarning("The Animator component of the panel has not been assigned, NUll reference");
                }
            }
         
        }
    }

}
