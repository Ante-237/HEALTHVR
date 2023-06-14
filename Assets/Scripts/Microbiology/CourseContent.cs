using System.Collections.Generic;
using UnityEngine;

namespace aptXR.Microbiology
{
    [CreateAssetMenu(fileName = "CourseContent", menuName = "MicroBiology/CourseContent")]
    public class CourseContent: ScriptableObject
    {

        public string CourseName;

        [Header("Course Objectives")]
        public List<string> CourseObjectives = new List<string>();

        [Header("Control Type")]
        public bool needHands = true;
        public bool needControllers = true;

        [Header("The Scene")]
        public string SceneName;


        public float courseDuration = 20;
        public bool courseCompleted = false;
        public int courseXP = 15;
        public bool isOpen = true;


        
    }
}