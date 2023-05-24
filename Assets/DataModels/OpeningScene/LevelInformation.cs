
using UnityEngine;


namespace aptXR.OpeningScene
{
    [CreateAssetMenu(fileName = "LevelInformation", menuName = "DataModel/OpeningScene/LevelInformation")]
    public class LevelInformation : ScriptableObject
    {

        public bool FirstTime = true;

        public bool StartFading = true;

        public int Usage = 0;
       
    }

}

