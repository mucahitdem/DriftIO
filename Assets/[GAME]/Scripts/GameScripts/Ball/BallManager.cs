using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.Ball
{
    public class BallManager : BaseComponent
    {
        [SerializeField]
        private BallWithRope ballWithRope;

        [SerializeField]
        private RotatingBall rotatingBall;

        [SerializeField]
        protected BasePlayerAndAi basePlayerAndAi;

        private BaseBall _ball;

        private void Awake()
        {
            _ball = ballWithRope;
        }

        #region Subs

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            basePlayerAndAi.onGetPowerUp += ActivateRotatingBall;
            rotatingBall.onPowerUpDurationEnded += DeactivateRotatingBall;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();

            basePlayerAndAi.onGetPowerUp -= ActivateRotatingBall;
            rotatingBall.onPowerUpDurationEnded -= DeactivateRotatingBall;
        }

        #endregion

        private void Update()
        {
            _ball.OnUpdate();
        }

        private void DeactivateRotatingBall() // todo fix
        {
            ControlBalls(false);
        }
        
        private void ActivateRotatingBall() // todo fix
        {
            ControlBalls(true);
        }

        private void ControlBalls(bool isRotatingBallActive)
        {
            ballWithRope.Go.SetActive(!isRotatingBallActive);
            rotatingBall.Go.SetActive(isRotatingBallActive);
            _ball = isRotatingBallActive ? (BaseBall) rotatingBall : ballWithRope;
        }
    }
}