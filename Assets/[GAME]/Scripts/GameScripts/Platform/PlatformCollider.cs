using System;
using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.Platform
{
    public class PlatformCollider : BaseComponent
    {
        [SerializeField]
        private PlatformColliderVariables platformColliderVariables;
        
        public override void SubscribeEvent()
        {
            PlatformManager.onPlatformWidened += ScaleCollider;
        }

        public override void UnsubscribeEvent()
        {
            PlatformManager.onPlatformWidened -= ScaleCollider;
        }
        
        private void ScaleCollider(int index)
        {
            float scale = platformColliderVariables.platformScales[index];
            TransformOfObj.DOScale(new Vector3(scale, TransformOfObj.localScale.y, scale),.3f);
        }
    }

    [Serializable]
    public class PlatformColliderVariables
    {
        public float[] platformScales;
    }
}