using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.State;
using UnityEngine;

namespace Scripts.GameScripts.Player
{
    public class PlayerManager : BasePlayerAndAi
    {
        protected override void Die()
        {
            base.Die();
            // end game 
            GlobalReferences.Instance.uiManager.ShowScreen("loseScreen");
        }
    }
}