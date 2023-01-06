using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.State;

namespace Scripts.State.GameStates
{
    public class GameState03_1Win : BaseGameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen("winScreen");
        }

        public override void ExitState()
        {
        }
    }
}