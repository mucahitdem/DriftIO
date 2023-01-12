using System;
using System.Collections.Generic;
using DG.Tweening;
using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.Platform;
using Scripts.GameScripts.Player;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        public Action opponentRemoved;
        
        public PlatformManager PlatformManager => platformManager;
        public PlatformCollider PlatformCollider => platformCollider;
        public PlatformRadiusController PlatformRadiusController => platformRadiusController;
        public PlatformPiecesManager PlatformPiecesManager => platformPiecesManager;
        
        #region References
        
        [SerializeField]
        private PlatformManager platformManager;
        
        [SerializeField]
        private PlatformCollider platformCollider;
        
        [SerializeField]
        private PlatformRadiusController platformRadiusController;

        [SerializeField]
        private PlatformPiecesManager platformPiecesManager;

        [SerializeField]
        private PlayerManager player;
        
        #endregion

        public List<BasePlayerAndAi> allOpponents = new List<BasePlayerAndAi>();
        
        protected override void OnAwake()
        {
            Application.targetFrameRate = 60;
            Time.timeScale = 1f;
        }

        public void RemoveItem(BasePlayerAndAi basePlayerAndAi)
        {
            allOpponents.Remove(basePlayerAndAi);
            opponentRemoved?.Invoke();
            
            
            if (allOpponents.Count == 1)
            {
                if (allOpponents[0] == player)
                {
                    GlobalReferences.Instance.uiManager.ShowScreen("winScreen");
                }
                else
                {
                    GlobalReferences.Instance.uiManager.ShowScreen("loseScreen");
                }

                DOVirtual.DelayedCall(1, ()=> Time.timeScale = 0f).SetId("FREEZEGAME");
            }
        }

        private void OnDisable()
        {
            DOTween.Kill("FREEZEGAME");
        }
    }
}