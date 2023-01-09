using Scripts.BaseGameScripts.CoinControl;
using Scripts.GameScripts.ParachuteControl;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField]
        private Coin coin;
        
        [SerializeField]
        private Parachute parachute;

        [SerializeField]
        private PowerUp powerUp;
        
        [HideInInspector]
        public PoolingPattern<Coin> coinPool;

        
        [HideInInspector]
        public PoolingPattern<Parachute> parachutePool;

        
        [HideInInspector]
        public PoolingPattern<PowerUp> parachuteBoxPool;
        
        protected void Awake()
        {
            StartCreation();
        }

        private void StartCreation()
        {
            // coinPool = new PoolingPattern<Coin>(coin);
            // parachutePool = new PoolingPattern<Parachute>(parachute);
            // parachuteBoxPool = new PoolingPattern<ParachuteBox>(parachuteBox);
        }
    }
}