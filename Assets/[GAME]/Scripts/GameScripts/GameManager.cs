using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.Platform;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        public PlatformManager PlatformManager => platformManager;
        public PlatformCollider PlatformCollider => platformCollider;
        public PlatformRadiusController PlatformRadiusController => platformRadiusController;

        #region References
        
        [SerializeField]
        private PlatformManager platformManager;
        
        [SerializeField]
        private PlatformCollider platformCollider;
        
        [SerializeField]
        private PlatformRadiusController platformRadiusController;

        #endregion
    }
}