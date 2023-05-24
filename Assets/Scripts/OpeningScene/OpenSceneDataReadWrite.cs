using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEditorInternal;

namespace aptXR.OpeningScene
{
    public class OpenSceneDataReadWrite
    {
        public LevelInformation LevelInformation;
        public VirtualTagModels VirtualTagModels;

        private static readonly string FilePath = "OpeningSceneData.json";
        private static readonly string VFilePath = "OpeningSceneTags.json";

        private static readonly string directoryPath = "OpeningScene";

        private static string _directoryPath;


        [System.Serializable]
        public class OpeningSceneData
        {
            public bool FirstTime;
            public int Usage;
        }

        [System.Serializable]
        public class VirtualTagData
        {
            public List<string> Tags;
        }

        public void SaveData()
        {
            OpeningSceneData data = new OpeningSceneData();
            data.FirstTime = LevelInformation.FirstTime;
            data.Usage = LevelInformation.Usage;

            VirtualTagData data2 = new VirtualTagData();
            data2.Tags = VirtualTagModels.Tags;

            string jsonData = JsonUtility.ToJson(data);
            string vJsonData = JsonUtility.ToJson(data2);

            // create the appropriate directory
            CreateOpeningSceneDirectory();

            

            string filePath = Path.Combine(_directoryPath, FilePath);
            string vFilePath = Path.Combine(_directoryPath, VFilePath);
            try
            {
                File.WriteAllText(filePath, jsonData);
                File.WriteAllText(vFilePath, vJsonData);
                Debug.Log("Writing to File Ante");
                Debug.LogWarning(filePath);
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Writing to Json File Failed For Virtual Tag and LevelInformation");
            }


        }

        public void LoadData()
        {
            
            string filePath = Path.Combine(_directoryPath, "OpeningSceneData.json");

            if (!Directory.Exists(_directoryPath))
            {

                if (File.Exists(filePath))
                {

                    string jsonData = File.ReadAllText(filePath);
                    OpeningSceneData data = JsonUtility.FromJson<OpeningSceneData>(jsonData);

                    LevelInformation.FirstTime = data.FirstTime;
                    LevelInformation.Usage = data.Usage;


                }
                else
                {
                    Debug.LogWarning(" The File Path For Reading the Information was not found");
                }
            }

        }

        public void CreateOpeningSceneDirectory()
        {
             _directoryPath = Application.persistentDataPath + "/" + directoryPath;

           

            try
            {
                Directory.CreateDirectory(_directoryPath);
            }
            catch(System.Exception)
            {
                Debug.LogError("Directory For Opening Scene Failed in Creation");
            }
        }
    }
}

