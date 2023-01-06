using Scripts.BaseGameScripts.Component;
using Scripts.State._Interface;

namespace Scripts.BaseGameScripts.State
{
    public abstract class BaseGameState : ComponentBase, IGameState
    {
        public abstract void InitState();

        public abstract void ExitState();
    }
}