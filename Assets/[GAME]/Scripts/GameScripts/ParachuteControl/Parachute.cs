using System;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.PowerUps;
using UnityEngine;

namespace Scripts.GameScripts.ParachuteControl
{
    public class Parachute : BaseComponent
    {
        [SerializeField]
        private PowerUp powerUp;

        private void OnTriggerEnter(Collider other)
        {
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
        }
    }
}