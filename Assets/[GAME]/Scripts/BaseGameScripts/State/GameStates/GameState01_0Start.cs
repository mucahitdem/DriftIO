using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.State;

namespace Scripts.State.GameStates
{
    public class GameState01_0Start : GameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen("startScreen");
        }

        public override void ExitState()
        {
        }
    }
}