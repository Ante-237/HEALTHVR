
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Assertions;

namespace aptXR
{
    public class LookATTArget : MonoBehaviour
    {
        
        public Transform _toRotate;
        public Transform _target;

        protected virtual void Start()
        {
            this.AssertField(_target, nameof(_target));
            this.AssertField(_toRotate, nameof(_toRotate));
        }

        protected virtual void Update()
        {
            Vector3 dirToTarget = (_target.position - _toRotate.position).normalized;
            _toRotate.LookAt(_toRotate.position - dirToTarget, Vector3.up);
        }
    }
}
