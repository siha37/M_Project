using MyFolder._01._Script._02._Object._08.PathFinding;
using UnityEditor;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._1001.Editor._08._PathFinding
{
    [CustomEditor(typeof(PathFindingGrid))]
    public class PathFindingGridEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            PathFindingGrid pathFindingGrid = (PathFindingGrid)target;
            if (GUILayout.Button("Create Node"))
            {
                pathFindingGrid.PathFinding();
            }
        }
    }
}
