using System;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.SO;
using UnityEngine;

namespace Scripts.GameScripts.Ball
{
    public abstract class BaseBall : BaseComponent
    {
        [SerializeField]
        protected BasePlayerAndAi basePlayerAndAi;
        
        [SerializeField]
        protected float ballHitForce;

        private bool _isInactive;

        protected virtual void Awake()
        {
            ballHitForce = InternalGameDataSo.InternalGameData.gameData.ballHitForce;
        }

        public abstract void OnUpdate();

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            basePlayerAndAi.onGetHit += OnHit;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            basePlayerAndAi.onGetHit -= OnHit;
        }

        protected void OnCollisionEnter(Collision other)
        {
            if(_isInactive)
                return;
            if (other.transform.CompareTag(Defs.TAG_AI) || other.transform.CompareTag(Defs.TAG_PLAYER))
            {
                BasePlayerAndAi carHit = other.transform.GetComponent<BasePlayerAndAi>();
                AddForce(carHit);
            }
        }

        private void AddForce(BasePlayerAndAi carHit)
        {
            Vector3 dir = (TransformOfObj.position - carHit.TransformOfObj.position).normalized;
            carHit.OnHit((-dir + Vector3.up) * UnityEngine.Random.Range(ballHitForce, ballHitForce *2f));
            basePlayerAndAi.onHitOtherPlayer?.Invoke();
        }

        private void OnHit()
        {
            _isInactive = true;
            Rb.constraints = RigidbodyConstraints.None;
        }
    }
}