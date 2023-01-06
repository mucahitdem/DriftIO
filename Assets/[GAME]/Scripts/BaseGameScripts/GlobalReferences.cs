using Scripts.BaseGameScripts.Managers;
using Scripts.BaseGameScripts.Pool;
using Scripts.BaseGameScripts.State;
using Scripts.BaseGameScripts.UI;
using Sirenix.OdinInspector;

namespace Scripts.BaseGameScripts
{
    public class GlobalReferences : SingletonMono<GlobalReferences>
    {
        public GameManager gameManager;
        public GameStateManager gameStateManager;
        public PoolManager poolManager;

        [Title("Managers")]
        public UiManager uiManager;

        protected override void OnAwake()
        {
        }
    }
}