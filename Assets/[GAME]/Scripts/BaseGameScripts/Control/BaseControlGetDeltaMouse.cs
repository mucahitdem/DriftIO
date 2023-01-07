using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control
{
    public class BaseControlGetDeltaMouse : BaseControl
    {
        protected CalculateDeltaMouse calculateDeltaMouse;

        [ReadOnly]
        public Vector2 DeltaMouse => calculateDeltaMouse.deltaMousePos;
        
        protected virtual void Awake()
        {
            calculateDeltaMouse = new CalculateDeltaMouse();
        }

        protected override void OnTapDown()
        {
            base.OnTapDown();
            calculateDeltaMouse.ResetValues();
        }

        protected override void OnTapHold()
        {
            base.OnTapHold();
            calculateDeltaMouse.CalculateDeltaMousePos();
        }
    }
}