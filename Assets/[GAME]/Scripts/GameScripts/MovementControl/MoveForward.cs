using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.MovementControl
{
    public class MoveForward : BaseComponent , IMovement
    {
        [SerializeField]
        private float forwardSpeed;
        
        public void Move() // call on fixed update
        {
            //TransformOfObj.position += TransformOfObj.forward * (forwardSpeed * Time.deltaTime);
        }
    }
}