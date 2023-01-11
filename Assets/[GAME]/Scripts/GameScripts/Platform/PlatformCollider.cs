using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
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
            if(!GameManager.Instance)
                return;
            
            GameManager.Instance.PlatformRadiusController.onPlatformRadiusChanged -= ScaleCollider;
        }
        
        private void ScaleCollider(float radius)
        {
            TransformOfObj.DOScale(new Vector3(radius, TransformOfObj.localScale.y, radius),.3f);
        }
    }
}