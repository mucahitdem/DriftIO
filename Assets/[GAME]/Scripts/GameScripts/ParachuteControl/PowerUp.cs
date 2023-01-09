using Scripts.GameScripts.Ability_System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ParachuteControl
{
    public class PowerUp : MonoBehaviour
    {
        [ReadOnly]
        public IAbility ability;

        public void Insert(IAbility newAbility)
        {
            ability = newAbility;
        }
    }
}