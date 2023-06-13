using Oculus.Interaction.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace aptXR.MasterMenu
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Scene Data Model")]
        [SerializeField] private SceneNames sceneNames;


        [Header("Toggles Menu's")]
        [SerializeField] private Toggle[] toggles = new Toggle[7];

        private SceneLoader sceneLoader;

        [Header("Toggle Low Panels")]
        [SerializeField] private Toggle[] toggleLow = new Toggle[3];

        [Header("Index of Various Rooms")]
        [SerializeField] private int AnatomyRoomIndex = 7;
        [SerializeField] private int EquipmentRoom = 1;
        [SerializeField] private int SurgeryLabs = 1;
        [SerializeField] private int SurgeryRecordingsLab = 1;
        [SerializeField] private int MultiplayerRoom = 1;
        [SerializeField] private int AIRoom = 1;
        [SerializeField] private int microBiologyRoom = 8;
        [SerializeField] private int settingsSceneIndex = 2;


        [Header("Lock Decision")]
        [SerializeField] private MasterModel MasterMenuSettings;


        [Header("Lock Sprites")]
        [SerializeField] private Image[] DimSprites = new Image[7];
        [SerializeField] private Image[] LockSprites = new Image[7];

        OVRDisplay ovr;



        private void OnEnable()
        {

            try
            {
                toggles[0].onValueChanged.AddListener(loadMicroBiology);
                toggles[1].onValueChanged.AddListener(loadAnatomyRoom);
                toggles[2].onValueChanged.AddListener(loadEquipmentRoom);
                toggles[3].onValueChanged.AddListener(loadSurgeryLabs);
                toggles[4].onValueChanged.AddListener(loadMultiplayerRoom);
                toggles[5].onValueChanged.AddListener(LoadSurgeryRecordingLabs);
                toggles[6].onValueChanged.AddListener(loadAIRoom);

                toggleLow[0].onValueChanged.AddListener(loadHelpSettings);
                toggleLow[1].onValueChanged.AddListener(loadSettingsScene);
                toggleLow[2].onValueChanged.AddListener(exitApplication);
             
            }catch(System.NullReferenceException)
            {
                Debug.LogWarning("The Toggles In Level Manager : MasterMenu Have not been Assigned");
            }
        


        }

        private void Start()
        {
            gameObject.AddComponent<SceneLoader>();
            sceneLoader = gameObject.GetComponent<SceneLoader>();

            setShowingright();
           

         
        }
       

        // TODO : middle option
        private void  loadSettingsScene(bool value)
        {

        }


        // TODO :  last option
        private void exitApplication(bool value)
        {

        }


        // TODO:  first menu
        private void loadHelpSettings(bool value)
        {
            if (value)
            {
                sceneLoader.Load(sceneNames.AllScenes[settingsSceneIndex]);
            }
        }






        // deems some panels and allow others to show depending on the settings
        void setShowingright()
        {
            for(int i = 0; i < MasterMenuSettings.Unlocked.Length; i++) {
                    DimSprites[i].enabled = MasterMenuSettings.Unlocked[i];
                    LockSprites[i].enabled = MasterMenuSettings.Unlocked[i];
            }
        }


        private void loadAScene(int value)
        {
            sceneLoader.Load(sceneNames.AllScenes[value]);
        }


        // TODO link to anatomy room main menu
        void loadAnatomyRoom(bool value)
        {
            if (toggles[1].isOn && !MasterMenuSettings.Unlocked[1])
            {
                loadAScene(AnatomyRoomIndex);
            }
        }

        //TODO
        void loadMicroBiology(bool value)
        {
            if (!MasterMenuSettings.Unlocked[0])
            {
                loadAScene(microBiologyRoom);
            }else if (value)
            {
                loadAScene(microBiologyRoom);
            }
        }
        
        // TODO 
        void loadEquipmentRoom(bool value)
        {
            if (toggles[2].isOn && !MasterMenuSettings.Unlocked[2])
            {
                loadAScene(EquipmentRoom);
            }
        }

        // TODO
        void loadSurgeryLabs(bool value)
        {
            if (toggles[3].isOn && !MasterMenuSettings.Unlocked[3])
            {
                loadAScene(SurgeryLabs);
            }
        }

        // TODO
        void LoadSurgeryRecordingLabs(bool value)
        {
            if (toggles[4].isOn && !MasterMenuSettings.Unlocked[4])
            {
                loadAScene(SurgeryRecordingsLab);
            }
        }

        // TODO
        void loadMultiplayerRoom(bool value)
        {
          if (toggles[5].isOn && !MasterMenuSettings.Unlocked[5])
            {
                loadAScene(MultiplayerRoom);
            }
        }

        // TODO
        void loadAIRoom(bool value)
        {
            if (toggles[6].isOn && !MasterMenuSettings.Unlocked[6])
            {
                loadAScene(AIRoom);
            }
        }

        // TODO
        private void OnDestroy()
        {
            toggles[0].onValueChanged.RemoveListener(loadMicroBiology);
            toggles[1].onValueChanged.RemoveListener(loadAnatomyRoom);
            toggles[2].onValueChanged.RemoveListener(loadEquipmentRoom);
            toggles[3].onValueChanged.RemoveListener(loadSurgeryLabs);
            toggles[4].onValueChanged.RemoveListener(loadMultiplayerRoom);
            toggles[5].onValueChanged.RemoveListener(LoadSurgeryRecordingLabs);
            toggles[6].onValueChanged.RemoveListener(loadAIRoom);

            toggleLow[0].onValueChanged.RemoveListener(loadHelpSettings);
            toggleLow[1].onValueChanged.RemoveListener(loadSettingsScene);
            toggleLow[2].onValueChanged.RemoveListener(exitApplication);

        }


        public void ExitApplicationOculus()
        {
            
            if(Application.platform == RuntimePlatform.Android)
            {
                OVRPlugin.SendEvent("quit");

            }
            else
            {
                Application.Quit();
            }
        }


       

    } 

}