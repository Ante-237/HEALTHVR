using UnityEngine;
using UnityEditor;
using Codice.Client.BaseCommands;

namespace aptXR
{
    public class CustomEditor : EditorWindow
    {
        [SerializeField]
        private SceneNames sceneNames;

        [MenuItem("Tools/Custom Editor")]
        public static void ShowWindow()
        {
            GetWindow<CustomEditor>("Custom Editor");
        }


        private string myString = "anTe working Again";
        private bool groupEnabled;
        private bool myBool = true;
        private float myFloat = 1.23f;


        void OnGUI()
        {
            GUILayout.Label("Base Settings", EditorStyles.boldLabel);
            myString = EditorGUILayout.TextField("Scene Names: ", sceneNames.AllScenes[0]);
            groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
            myBool = EditorGUILayout.Toggle("Toggle", myBool);
            myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
            EditorGUILayout.EndToggleGroup();
        }
    }
}