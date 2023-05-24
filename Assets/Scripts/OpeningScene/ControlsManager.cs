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

        [SerializeField]
        private Controller RightController;
        [SerializeField]
        private Controller LeftController;


        private bool _isHands = false;
        private bool _isControllers = true;


        public bool IsHands
        {
            get { return _isHands; } 
        }

        public bool IsControllers
        {
            get { return _isControllers; }
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
            else if(RightController.IsConnected && LeftController.IsConnected)
            {
                _isControllers = true;
                _isHands = false;
            }        
        }



        
        
    }
}
