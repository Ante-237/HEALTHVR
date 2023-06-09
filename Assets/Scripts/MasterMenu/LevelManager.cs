using JetBrains.Annotations;
using Oculus.Interaction.Samples;
using System;
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
        [SerializeField] private Toggle[] toggles = new Toggle[6];

        private SceneLoader sceneLoader;

        [Header("Index of Various Rooms")]
        [SerializeField] private int AnatomyRoomIndex = 7;
        [SerializeField] private int EquipmentRoom = 1;
        [SerializeField] private int SurgeryLabs = 1;
        [SerializeField] private int SurgeryRecordingsLab = 1;
        [SerializeField] private int MultiplayerRoom = 1;
        [SerializeField] private int AIRoom = 1;



        private void OnEnable()
        {

            try
            {
                toggles[0].onValueChanged.AddListener(loadAnatomyRoom);
                toggles[1].onValueChanged.AddListener(loadEquipmentRoom);
                toggles[2].onValueChanged.AddListener(loadSurgeryLabs);
                toggles[3].onValueChanged.AddListener(loadMultiplayerRoom);
                toggles[4].onValueChanged.AddListener(LoadSurgeryRecordingLabs);
                toggles[5].onValueChanged.AddListener(loadAIRoom);
            }catch(System.NullReferenceException)
            {
                Debug.LogWarning("The Toggles In Level Manager : MasterMenu Have not been Assigned");
            }
        


        }

        private void Start()
        {
            gameObject.AddComponent<SceneLoader>();
            sceneLoader = gameObject.GetComponent<SceneLoader>();
        }


        private void loadAScene(int value)
        {
            sceneLoader.Load(sceneNames.AllScenes[value]);
        }


        // TODO link to anatomy room main menu
        void loadAnatomyRoom(bool value)
        {
            if (toggles[0].isOn)
            {
                loadAScene(AnatomyRoomIndex);
            }
        }

        // TODO 
        void loadEquipmentRoom(bool value)
        {
            if (toggles[1].isOn)
            {
                loadAScene(EquipmentRoom);
            }
        }

        // TODO
        void loadSurgeryLabs(bool value)
        {
            if (toggles[2].isOn)
            {
                loadAScene(SurgeryLabs);
            }
        }

        // TODO
        void LoadSurgeryRecordingLabs(bool value)
        {
            if (toggles[4].isOn)
            {
                loadAScene(SurgeryRecordingsLab);
            }
        }

        // TODO
        void loadMultiplayerRoom(bool value)
        {
          if (toggles[3].isOn)
            {
                loadAScene(MultiplayerRoom);
            }
        }

        // TODO
        void loadAIRoom(bool value)
        {
            if (toggles[5].isOn)
            {
                loadAScene(AIRoom);
            }
        }

        // TODO
        private void OnDestroy()
        {

            toggles[0].onValueChanged.RemoveListener(loadAnatomyRoom);
            toggles[1].onValueChanged.RemoveListener(loadEquipmentRoom);
            toggles[2].onValueChanged.RemoveListener(loadSurgeryLabs);
            toggles[3].onValueChanged.RemoveListener(loadMultiplayerRoom);
            toggles[4].onValueChanged.RemoveListener(LoadSurgeryRecordingLabs);
            toggles[5].onValueChanged.RemoveListener(loadAIRoom);
        }


    } 

}