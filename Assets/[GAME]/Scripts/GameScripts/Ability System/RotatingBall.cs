using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.Ability_System
{
    public class RotatingBall : BaseComponent, IAbility
    {
        private float _timer;
        private readonly float _rotateSpeed;
        private readonly Transform _objToRotateAround;

        public RotatingBall(float timer, float rotateSpeed, Transform objToRotateAround)
        {
            _timer = timer;
            _rotateSpeed = rotateSpeed;
            _objToRotateAround = objToRotateAround;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Destroy(this);
            }
            else
            {
                Use();
            }
        }

        public void Use()
        {
            TransformOfObj.RotateAround(_objToRotateAround.position,Vector3.up, _rotateSpeed);
        }
    }
}