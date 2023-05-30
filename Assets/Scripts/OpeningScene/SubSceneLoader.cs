using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;

public class SubSceneLoader : MonoBehaviour
{
    public string addressToAdd;
    SceneInstance sceneInstance;

    void Start()
    {
       // LoadScene(); 
    }


    void LoadScene()
    {
        if (string.IsNullOrEmpty(addressToAdd))
        {
            Debug.LogWarning("Address For the Scene Not Added.");
        }
        else
        {
            Addressables.LoadSceneAsync(addressToAdd, LoadSceneMode.Additive).Completed += LoadSceneToOpening;
        }
    }


   void LoadSceneToOpening(AsyncOperationHandle<SceneInstance> obj)
   {
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Loading Completed");
            sceneInstance = obj.Result;
        }
        else
        {
            Debug.LogWarning("Failed to Load Scene");
        }
   }
}
