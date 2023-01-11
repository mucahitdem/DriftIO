using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace Scripts.GameScripts.SO
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "DriftIO/Game Data", order = 0)]
    public class InternalGameDataSo : ScriptableObject
    {
        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static InternalGameDataSo s_internalGameData;

        public static InternalGameDataSo InternalGameData => s_internalGameData ??= Resources.Load<InternalGameDataSo>("Internal Game Data");

        private void FindHolesDataAsset()
        {
            if (InternalGameData) return;
            Debug.LogError("Internal Game Data asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
        
#if UNITY_EDITOR
        [Button]
        public void SetDataDirty()
        {
            EditorUtility.SetDirty(InternalGameData);
        }
#endif

        
        public GameData gameData;
    }

    [Serializable]
    public class GameData
    {
        [FoldoutGroup("Ball with rope")]
        public float ballHitForce;
        
        [FoldoutGroup("Rotating ball")]
        public float rotatingBallHitForce;
        [FoldoutGroup("Rotating ball")]
        public float rotateSpeed;
        
        [FoldoutGroup("AI")]
        public float turnSpeed;
        [FoldoutGroup("AI")]
        public float maxPercentageAiCanBeAwayOnArenaCenter;
        [FoldoutGroup("AI")]
        public float updateNearestOpponentEveryXSecond;
        [FoldoutGroup("AI")]
        public float ballHitRadius;

        [FoldoutGroup("AI And Player")]
        public float moveSpeed;

        [FoldoutGroup("UI")]
        public List<Sprite> goodEmojis;
        [FoldoutGroup("UI")]
        public List<Sprite> badEmojis;
    }
}