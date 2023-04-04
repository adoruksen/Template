using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class DeveloperActions : EditorWindow
{
    public int TargetLevel;

    private Vector2 _scrollPosition;

    [MenuItem("Doruk Editor/Developer Actions",priority = 1)]
    private static void ShowWindow()
    {
        var window = GetWindow<DeveloperActions>();
        window.titleContent = new GUIContent("Developer Actions");
        window.Show();
    }

    private void OnGUI()
    {
        var so = new SerializedObject(this);
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
        GameSetup();
        EditorGUILayout.Space();
        EditorGUILayout.Separator();
        RenderGameControls(so);
        EditorGUILayout.Space();
        EditorGUILayout.EndScrollView();
    }

    private void GameSetup()
    {
        EditorGUILayout.LabelField("Project Initializer", EditorStyles.boldLabel);

        if(GUILayout.Button("Initialize Project", EditorStyles.miniButtonMid))
        {
            #region Folder Architecture
            var folders = new List<string> { "Art","Scenes", "Levels", "Prefabs", "Scriptable Objects", "Scripts" };
            var artFolders = new List<string> { "Animations", "Textures", "Materials", "Models" };

            if (!AssetDatabase.IsValidFolder("Assets/_Game"))
                AssetDatabase.CreateFolder("Assets", "_Game");

            foreach (var folder in folders)
            {
                if (!AssetDatabase.IsValidFolder("Assets/_Game" + folder))
                    AssetDatabase.CreateFolder("Assets/_Game", folder);
            }

            foreach (var folder in artFolders)
            {
                if (!AssetDatabase.IsValidFolder("Assets/_Game/Art" + folder))
                    AssetDatabase.CreateFolder("Assets/_Game/Art", folder);
            }
            #endregion
        }
    }

    private void RenderGameControls(SerializedObject so)
    {
        var targetLevel = so.FindProperty("TargetLevel");
        EditorGUILayout.Separator();
        EditorGUILayout.LabelField(" Game Methods ", EditorStyles.boldLabel);
        EditorGUILayout.LabelField(" Methods below require extending AncientGameManager class. ", EditorStyles.helpBox);
        EditorGUILayout.PropertyField(targetLevel, true);
        if (GUILayout.Button("Jump to Level", EditorStyles.miniButton))
        {
            if (!Application.isPlaying) Debug.Log(" Works on play mode only. Hit ctrl + P to start play mode ");

            var ancientGameManager = FindObjectOfType<AncientGameManager>();
            if (ancientGameManager != null) ancientGameManager.JumpToLevel(TargetLevel);
            else Debug.LogError("AncientGameManager not found or not extended at all");
        }

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button(" Previous Level ", EditorStyles.miniButton))
        {
            if (!Application.isPlaying) Debug.Log(" Works on play mode only. Hit ctrl + P to start play mode ");
            
            var ancientGameManager = FindObjectOfType<AncientGameManager>();
            if (ancientGameManager != null) ancientGameManager.PreviousLevel();
            else Debug.LogError("AncientGameManager not found or not extended at all");
        }
        if (GUILayout.Button(" Restart Level ", EditorStyles.miniButton))
        {
            if (!Application.isPlaying) Debug.Log(" Works on play mode only. Hit ctrl + P to start play mode ");

            var ancientGameManager = FindObjectOfType<AncientGameManager>();
            if (ancientGameManager != null) ancientGameManager.RestartLevel();
            else Debug.LogError("AncientGameManager not found or not extended at all");
        }
        if (GUILayout.Button(" Skip Level ", EditorStyles.miniButton))
        {
            if (!Application.isPlaying) Debug.Log(" Works on play mode only. Hit ctrl + P to start play mode ");

            var ancientGameManager = FindObjectOfType<AncientGameManager>();
            if (ancientGameManager != null) ancientGameManager.SkipLevel();
            else Debug.LogError("AncientGameManager not found or not extended at all");
        }
        EditorGUILayout.EndHorizontal();
        so.ApplyModifiedProperties();
    }
}
