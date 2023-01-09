using System;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.Ability_System;
using UnityEngine;

namespace Scripts.GameScripts.ParachuteControl
{
    public class Parachute : BaseComponent
    {
        [SerializeField]
        private PowerUp powerUp;

        [SerializeField]
        private IAbility ability;

        private void Awake()
        {
            ability = GetComponent<IAbility>();
        }

        private void OnCollisionEnter(Collision other)
        {
            DebugHelper.LogRed(other.transform.tag);
            if (other.transform.CompareTag(Defs.TAG_GROUND))
            {
                CreateBox();
                Go.SetActive(false);
            }
        }

        private void CreateBox()
        {
            var position = TransformOfObj.position;
            PowerUp createdPowerUp = Instantiate(powerUp, new Vector3(position.x, 0, position.z), Quaternion.identity);
            createdPowerUp.Insert(ability);
        }
    }
}