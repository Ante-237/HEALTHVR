using Oculus.Interaction.Input;
using UnityEngine;

namespace aptXR.OpeningScene
{
    public class ControlsManager : MonoBehaviour
    {

        [Header("The Hands")]
        [SerializeField]
        private OVRHand RightHand;
        [SerializeField] 
        private OVRHand LeftHand;


        private bool _isHands = false;
        private bool _isControllers = true;


        public bool IsHands
        {
            get { return _isHands; } 
        }

        public bool IsControllers
        {
            get { return IsControllers; }
        }

        private void Update()
        {
            CheckIfHands();
        }



        void CheckIfHands()
        {
            if(RightHand.IsTracked && LeftHand.IsTracked)
            {
                _isHands = true;
                _isControllers = false;
            }
            else
            {
                _isControllers = true;
                _isHands = false;
            }        
        }



        
        
    }
}
