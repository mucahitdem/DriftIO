using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.BaseGameScripts.EventManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.Platform
{
    public class PlatformPiecesManager : EventSubscriber
    {
        [FoldoutGroup("Platform Piece Groups")]
        [SerializeField]
        private List<PlatformPieceGroup> platformPieceGroups = new List<PlatformPieceGroup>();

        private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(.05f);

        public override void SubscribeEvent()
        {
            PlatformManager.onPlatformWidened += StartReleasingPieces;
        }

        public override void UnsubscribeEvent()
        {
           PlatformManager.onPlatformWidened -= StartReleasingPieces;
        }
        
        private void StartReleasingPieces(int index)
        {
            StartCoroutine(ReleasePieces(platformPieceGroups[index]));
        }
        
        private IEnumerator ReleasePieces(PlatformPieceGroup platformPiecesGroup)
        {
            int pieceCount = platformPiecesGroup.platformPieces.Count;
            for (int i = 0; i < pieceCount; i++)
            {
                var randomCount = UnityEngine.Random.Range(0, platformPiecesGroup.platformPieces.Count - 1);
                
                platformPiecesGroup.platformPieces[randomCount].ReleasePiece();
                platformPiecesGroup.platformPieces.RemoveAt(randomCount);
                yield return _waitForSeconds;
            }
        }
    }
    
    [Serializable]
    public class PlatformPieceGroup
    {
        public List<PlatformPiece> platformPieces = new List<PlatformPiece>();
    }
}