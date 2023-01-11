using System;
using Scripts.BaseGameSystemRelatedScripts.Upgrade;
using Scripts.GameScripts.SO;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Scripts.BaseGameSystemRelatedScripts.Editor
{
    public class GameWindow : OdinMenuEditorWindow
    {
        [MenuItem("Designer Tools/Settings")]
        private static void OpenWindow()
        {
            GetWindow<GameWindow>().Show();
        }


        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            tree.Selection.SupportsMultiSelect = false;
            tree.Add("Opponents Data", OpponentsDataSo.OpponentsData);
            tree.Add("Internal Game Data", InternalGameDataSo.InternalGameData);

            return tree;
        }

        [Serializable]
        public class HoleGameWindowFunctionality
        {
            [Button]
            public void SetDataDirty()
            {
                OpponentsDataSo.OpponentsData.SetDataDirty();
            }
        }
    }
}