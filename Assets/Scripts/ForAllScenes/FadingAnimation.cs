using System;
using UnityEngine;

namespace aptXR
{

    public class FadingAnimation : MonoBehaviour
    {
        [SerializeField]
        [Header("Animator For Fading")]
        private Animator animator;


        [Header("AnimationSpeed")]
        [SerializeField]
        private float _animationSpeedFadingIn = 1.0f;
        [SerializeField]
        private float _animationSpeedFadingOut = 1.0f;

        

        [Header("Animation Clip Adjust")]
        [SerializeField]
        private AnimationClip FadingIn;
        [SerializeField]
        private AnimationClip FadingOut;


        private readonly int FadeIn = Animator.StringToHash("FadeIn");
        private readonly int FadeOut = Animator.StringToHash("FadeOut");


        public void FadeAnimationIn()
        {
            if (animator != null)
            {
                animator.SetBool(FadeIn, true);
                animator.SetBool(FadeOut, false);
            }
            else
            {
                Debug.LogWarning("The animator Component has a null Reference");
            }
            
        }

        public void FadeAnimationOut()
        {
            if (animator != null)
            {
                animator.SetBool(FadeOut, true);
                animator.SetBool(FadeIn, false);
            }
            else
            {
                Debug.LogWarning("The animator Component has a null Reference");
            }
           
        }
        
    }
}

