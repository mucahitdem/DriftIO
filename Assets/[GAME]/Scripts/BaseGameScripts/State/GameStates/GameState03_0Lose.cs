using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.State;

namespace Scripts.State.GameStates
{
    public class GameState03_0Lose : GameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen("loseScreen");
        }

        public override void ExitState()
        {
        }
    }
}