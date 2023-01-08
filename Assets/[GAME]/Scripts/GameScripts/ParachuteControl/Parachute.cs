using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ParachuteControl
{
    public class Parachute : BaseComponent , IPoolObject<Parachute>
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(Defs.TAG_GROUND))
            {
                
            }
        }

        private void DisableParachute()
        {
            
        }

        #region Pool Variables

        [FoldoutGroup("Pool")]
        public PoolingPattern<Parachute> Pool { get; set; }
        
        [FoldoutGroup("Pool")]
        [ShowInInspector]
        public Parachute ObjToPool { get; set; }
        [FoldoutGroup("Pool")]
        [ShowInInspector]
        public int ItemCount { get; set; }
        
        [FoldoutGroup("Pool")]
        [ShowInInspector]
        public HideFlags HideFlag { get; set; }
        
        
        public void AddToPool()
        {
            Pool.AddBackToPool(this);
        }

        public void SetPool(PoolingPattern<Parachute> pool)
        {
            Pool = pool;
        }

        #endregion
    }
}