using System;
using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.Platform
{
    public class PlatformCollider : BaseComponent
    {
        public override void SubscribeEvent()
        {
            GameManager.Instance.PlatformRadiusController.onPlatformRadiusChanged += ScaleCollider;
        }

        public override void UnsubscribeEvent()
        {
            GameManager.Instance.PlatformRadiusController.onPlatformRadiusChanged -= ScaleCollider;
        }
        
        private void ScaleCollider(float radius)
        {
            TransformOfObj.DOScale(new Vector3(radius, TransformOfObj.localScale.y, radius),.3f);
        }
    }
}