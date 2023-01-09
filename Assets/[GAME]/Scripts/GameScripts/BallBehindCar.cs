using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.Ability_System;

namespace Scripts.GameScripts
{
    public class BallBehindCar : BaseComponent
    {
        private IAbility _ability;

        public void InsertNewAbility(IAbility newAbility)
        {
            _ability = newAbility;
            _ability.Use();
        }
    }
}