using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Scripts.GameScripts.SO
{
    [CreateAssetMenu(fileName = "Opponents", menuName = "DriftIO/All Opponents", order = 0)]
    public class OpponentsDataSo : ScriptableObject
    {
        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static OpponentsDataSo s_opponentsData;

        public static OpponentsDataSo OpponentsData => s_opponentsData ??= Resources.Load<OpponentsDataSo>("Opponents");

        private void FindHolesDataAsset()
        {
            if (OpponentsData) return;
            Debug.LogError("HoleData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion

#if UNITY_EDITOR
        [Button]
        public void SetDataDirty()
        {
            EditorUtility.SetDirty(OpponentsData);
        }
#endif
        
        
        public List<PlayerAiCommonDataSo> playerAiCommonDataSo = new List<PlayerAiCommonDataSo>();
    }
}