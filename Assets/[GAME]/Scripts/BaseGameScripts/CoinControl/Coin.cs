using System;
using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Pool;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class Coin : ComponentBase, IPoolObject<Coin>
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Sprite sprite;

        private void Awake()
        {
            if(sprite)
                image.sprite = sprite;
        }


        public void MoveToCounter(Vector2 targetPos, float duration = 1f)
        {
            Rect.DOMove(targetPos, duration);
        }

        #region Pool

        public PoolingPattern<Coin> Pool { get; set; }
        [FoldoutGroup("Pool")]
        [field:SerializeField]
        public Coin ObjToPool { get; set; }
        [FoldoutGroup("Pool")]
        [field:SerializeField]
        public int ItemCount { get; set; }
        [FoldoutGroup("Pool")]
        [field:SerializeField]
        public HideFlags HideFlag { get; set; }
        
        public void AddToPool()
        {
            Pool.AddBackToPool(this);
        }

        public void SetPool(PoolingPattern<Coin> pool)
        {
            Pool = pool;
        }

        #endregion
        
    }
}