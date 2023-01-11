using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.Rope
{
    public class RopeWithLineRenderer : BaseComponent, IRope
    {
        [SerializeField]
        private Transform[] lineRendPoints;

        [SerializeField]
        private BasePlayerAndAi basePlayerAndAi;
        
        private int _lineRendPointCount;
        private bool _ropeEnabled;
        
        private void Awake()
        {
            _ropeEnabled = true;
            _lineRendPointCount = lineRendPoints.Length;
            LineRend.positionCount = _lineRendPointCount;
        }

        #region Subs

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            basePlayerAndAi.onGetPowerUp += DisableRope;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            basePlayerAndAi.onGetPowerUp -= DisableRope;
        }

        #endregion

        public void EnableRope()
        {
            RopeActivateControl(true);
        }

        public void DisableRope()
        {
            RopeActivateControl(false);
        }

        private void RopeActivateControl(bool isEnabled)
        {
            _ropeEnabled = isEnabled;
            LineRend.enabled = isEnabled;
        }

        public void UpdateRope()
        {
            if (_ropeEnabled)
            {
                for (int i = 0; i < lineRendPoints.Length; i++)
                {
                    LineRend.SetPosition(i, lineRendPoints[i].position);
                }
            }
        }
    }
}