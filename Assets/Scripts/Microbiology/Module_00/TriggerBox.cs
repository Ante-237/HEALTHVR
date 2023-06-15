using UnityEngine;


namespace aptXR.Microbiology.module_00
{
    public class TriggerBox : MonoBehaviour
    {
        public bool TriggerEntered = false;

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.GetComponent<VirtualTag>()?.GetTag() == "cell")
            {
                TriggerEntered = true;
            }
        }
    }
}