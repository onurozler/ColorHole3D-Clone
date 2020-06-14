using System.Linq;
using Game.CollectableObjectSystem.Base;
using Game.LevelSystem.Model;
using UnityEditor;
using UnityEngine;

namespace Game.LevelSystem.Editor
{
    public class LevelSaveEditor : EditorWindow
    {
        private LevelData _currentLevel;
        
        [MenuItem("LevelEditor/Level Save")]
        private static void CastlePieceSetting()
        {
            GetWindow<LevelSaveEditor>("Level Save System");
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Select Level Data",EditorStyles.boldLabel);
            _currentLevel = (LevelData)EditorGUILayout.ObjectField(_currentLevel, typeof(LevelData), true);
            
            EditorGUILayout.LabelField("Save Current Collectables to Data",EditorStyles.boldLabel);
            if (GUILayout.Button("Save"))
            {
                Save();
            }
            
            EditorGUILayout.EndVertical();
        }

        private void Save()
        {
            var collectables = FindObjectsOfType<CollectableBase>().ToList();
            if (collectables.Count <= 0 || _currentLevel == null)
                return;

            foreach (var collectable in collectables)
            {
                _currentLevel.CollectablePositions.Add(collectable.transform.position);
            }
            
            EditorUtility.SetDirty(_currentLevel);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
