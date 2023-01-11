using System;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameSystemRelatedScripts.Timer;
using Scripts.GameScripts.SO;
using UnityEngine;

namespace Scripts.GameScripts.Ball
{
    public class RotatingBall : BaseBall
    {
        public Action onPowerUpDurationEnded;
        
        [SerializeField]
        private Timer timer;

        private float _rotateSpeed;

        [SerializeField]
        private Transform objToRotateAround;

        private bool _use;

        protected override  void Awake()
        {
            base.Awake();
            GetVariables();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            StartRotating();
        }

        private void GetVariables()
        {
            GameData gameData = InternalGameDataSo.InternalGameData.gameData;
            _rotateSpeed = gameData.rotateSpeed;
        }
        
        #region Subs

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            timer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            timer.onTimerEnded -= OnTimerEnded;
        }
        
        #endregion
        
        public override void OnUpdate()
        {
            if (_use)
                Rotate();
        }
        
        private void OnTimerEnded()
        {
            ReverseStopPlay();
            onPowerUpDurationEnded?.Invoke();
            DebugHelper.LogRed("ROTATING BALL TIMER ENDED");
        }

        private void StartRotating()
        {
            timer.StartTimer();
            ReverseStopPlay();
        }
        
        private void ReverseStopPlay()
        {
            _use = !_use;
        }

        private void Rotate()
        {
            TransformOfObj.RotateAround(objToRotateAround.position, Vector3.up, _rotateSpeed);
        }
    }
}