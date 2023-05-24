using System.Collections.Generic;
using UnityEngine;

namespace aptXR {

    [CreateAssetMenu(fileName = "SceneNames", menuName = "DataModel/SceneNames")]
    public class SceneNames : ScriptableObject
    {

        public static readonly List<string> AllScenes = new List<string>() { "OpeningScene", "LoginScene" };

    }

}


