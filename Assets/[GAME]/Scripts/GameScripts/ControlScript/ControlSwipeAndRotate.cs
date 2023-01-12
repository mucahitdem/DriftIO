using Scripts.BaseGameScripts.Control;
using Scripts.BaseGameSystemRelatedScripts;
using UnityEngine;

namespace Scripts.GameScripts.ControlScript
{
    public class ControlSwipeAndRotate : BaseControlGetDeltaMouse
    {
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

        protected override void OnTapHoldAndNotMove()
        {
            base.OnTapHoldAndNotMove();
            Swipe();
        }

        private void Swipe()
        {
            var objRot = TransformOfObj.eulerAngles;

            var yRot = objRot.y;
            yRot = Mathf.Lerp(yRot, yRot + (mouseDamp * (DeltaMouse.x / _screenWidth)), Time.deltaTime * lerpMultiplier);

            TransformOfObj.eulerAngles = new Vector3(objRot.x, yRot, objRot.z);
            //calculateDeltaMouse.ResetValues();
        }
    }
}