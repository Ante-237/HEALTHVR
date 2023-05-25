
using Oculus.Platform;
using UnityEngine;

namespace aptXR {

    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;    

        public static GameManager Instance { get { return instance; } }



        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
             

            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

        }
    }

}

