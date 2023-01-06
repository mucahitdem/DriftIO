using Scripts.BaseGameScripts.CoinControl;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField]
        private Coin coin;
        
        [HideInInspector]
        public PoolingPattern<Coin> coinPool;

        
        protected void Awake()
        {
            StartCreation();
        }

        private void StartCreation()
        {
            coinPool = new PoolingPattern<Coin>(coin.ObjToPool);
        }
    }
}