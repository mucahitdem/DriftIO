using System;
using Scripts.BaseGameScripts.EventManagement;

namespace Scripts.GameScripts.Platform
{
    public class PlatformRadiusController : EventSubscriber
    {
        public Action<float> onPlatformRadiusChanged;

        public PlatformColliderVariables platformColliderVariables;
        private float _platformRadius;

        private void Awake()
        {
            _platformRadius = platformColliderVariables.platformScales[0];
        }

        public override void SubscribeEvent()
        {
            PlatformManager.onPlatformWidened += OnPlatformRadiusChanged;
        }

        public override void UnsubscribeEvent()
        {
            PlatformManager.onPlatformWidened -= OnPlatformRadiusChanged;
        }

        private void OnPlatformRadiusChanged(int index)
        {
            _platformRadius = platformColliderVariables.platformScales[index + 1];
            onPlatformRadiusChanged?.Invoke(_platformRadius);
        }
    }
    
    [Serializable]
    public class PlatformColliderVariables
    {
        public float[] platformScales;
    }
}