using System;
using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.SO;
using Scripts.GameScripts.Trigger;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts
{
    public abstract class BasePlayerAndAi : BaseComponent
    {
        public Action onGetPowerUp;
        public Action onGetHit;
        public Action onHitOtherPlayer;
        
        [FoldoutGroup("Data")]
        public PlayerAiCommonDataSo data;

        [SerializeField]
        private GfxVariables gfxVariables;

        [ReadOnly]
        public bool canControl;
        
        private IMovement _movement;
        private ITriggerCollisionHandler _triggerCollisionHandler;

        protected virtual void Awake()
        {
            canControl = true;
            _movement = GetComponent<IMovement>();
            gfxVariables.UpdateMaterials(data);
        }
        
        protected virtual void FixedUpdate()
        {
            if(canControl)
                _movement?.Move();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Defs.TAG_POWER_UP))
            {
                other.gameObject.SetActive(false);
                onGetPowerUp?.Invoke();  
            }
            else if (other.CompareTag(Defs.TAG_SEA))
            {
                Die();  
            }
        }

        public void OnHit(Vector3 dir)
        {
            onGetHit?.Invoke();
            Die();
            AddForce(dir);
        }

        private void AddForce(Vector3 dir)
        {
            Rb.velocity = Vector3.zero;
            Rb.constraints = RigidbodyConstraints.None;
            Rb.AddForce(dir, ForceMode.Impulse);
            Rb.angularVelocity = Random.insideUnitSphere * Random.Range(30f, 50f);
        }

        protected virtual void Die()
        {
            canControl = false;
            DOVirtual.DelayedCall(1, ()=> transform.parent.gameObject.SetActive(false));
            GameManager.Instance.RemoveItem(this);
        }
    }

    [Serializable]
    public class GfxVariables
    {
        [FoldoutGroup("Meshes")]
        public MeshRenderer car;
        [FoldoutGroup("Meshes")]
        public MeshRenderer ballWithRope;
        [FoldoutGroup("Meshes")]
        public MeshRenderer rotatingBall;

        public void UpdateMaterials(PlayerAiCommonDataSo dataSo)
        {
            car.sharedMaterial = dataSo.carMaterial;
            ballWithRope.sharedMaterial = dataSo.ballMaterial;
            rotatingBall.sharedMaterial = dataSo.ballMaterial;
        }
    }
}