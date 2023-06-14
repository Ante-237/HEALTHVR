using UnityEngine;

namespace aptXR.Microbiology.module_00
{
    //TODO : bot is idle in background
    //TODO : bot introduces the objectives of the course.
    //TODO : bot introduces the progress board.
    //TODO : bot introduces the pointers to follow when learning.
    //TODO : check if components have been assigned


    public class module_00_bot : MonoBehaviour
    {

        [Header("Bot Animator")]
        [SerializeField] private Animator animatorBot;

        private readonly int idle = Animator.StringToHash("Idle");
        private readonly int showObjectives = Animator.StringToHash("showObjectives");
        private readonly int moveAway = Animator.StringToHash("moveAway");


        private void Awake()
        {
            TestAnimator();
        }



        public void SetObjectivesActions()
        {
                animatorBot.SetBool(idle, false);
                animatorBot.SetBool(showObjectives, true);     
        }

        public void SetIdleActions()
        {
            animatorBot.SetBool(idle, true);
            animatorBot.SetBool(showObjectives, false);
            animatorBot.SetBool(moveAway, false);
           
        }

        public void SetMoveAway()
        {
            animatorBot.SetBool(moveAway, true);

        }

        public void TestAnimator()
        {
            if(animatorBot == null)
            {
                Debug.LogWarning("BotAnimator has not been assigned");
            }
        }

    }
}