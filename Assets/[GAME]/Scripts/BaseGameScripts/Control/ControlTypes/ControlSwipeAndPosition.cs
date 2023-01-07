using Scripts.GameScripts;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control.ControlTypes
{
    public class ControlSwipe : BaseControlGetDeltaMouse
    {
        [Header("Swipe Variables")]
        public float clampMaxVal;

        public float lerpMultiplier = 1;
        public float mouseDamp = 600;

        private float _screenWidth;


        protected override void Awake()
        {
            base.Awake();
            _screenWidth = Screen.width;
        }

        protected override void OnTapHold()
        {
            base.OnTapHold();
            Swipe();
            
        }


        private void Swipe()
        {
            var objPos = TransformOfObj.position;

            var xPos = objPos.x;
            xPos = Mathf.Lerp(xPos, xPos + mouseDamp * (DeltaMouse.x / _screenWidth), Time.deltaTime * lerpMultiplier);
            xPos = Mathf.Clamp(xPos, -clampMaxVal, clampMaxVal);

            TransformOfObj.position = new Vector3(xPos, objPos.y, objPos.z);

            calculateDeltaMouse.ResetValues();
        }
    }
}