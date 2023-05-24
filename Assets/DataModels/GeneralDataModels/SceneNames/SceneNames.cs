
using System.Collections.Generic;
using UnityEngine;

namespace aptXR 
{

    [CreateAssetMenu(fileName = "SceneNames", menuName = "DataModel/SceneNames")]
    public class SceneNames : ScriptableObject
    {

        public List<string> AllScenes = new List<string>(1) { "OpeningScene" };

    }

}


