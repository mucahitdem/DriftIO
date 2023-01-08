using Scripts.BaseGameScripts.Pool;
using Scripts.GameScripts.Ability_System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ParachuteControl
{
    public class ParachuteBox : MonoBehaviour, IPoolObject<ParachuteBox>
    {
        [ReadOnly]
        public IAbility ability;
        
        
        #region Pool

        [FoldoutGroup("Pool")]
        public PoolingPattern<ParachuteBox> Pool { get; set; }
        
        [FoldoutGroup("Pool")]
        [ShowInInspector]
        public ParachuteBox ObjToPool { get; set; }
       
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

        public void SetPool(PoolingPattern<ParachuteBox> pool)
        {
            Pool = pool;
        }
        #endregion
    }
}