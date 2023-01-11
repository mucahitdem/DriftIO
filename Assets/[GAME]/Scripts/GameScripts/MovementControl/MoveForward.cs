using System;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.SO;
using UnityEngine;

namespace Scripts.GameScripts.MovementControl
{
    public class MoveForward : BaseComponent , IMovement
    {
        private float _forwardSpeed;

        private void Awake()
        {
            _forwardSpeed = InternalGameDataSo.InternalGameData.gameData.moveSpeed;
        }

        public void Move() // call on fixed update
        {
            TransformOfObj.position += TransformOfObj.forward * (_forwardSpeed * Time.deltaTime);
        }
        
    }
}