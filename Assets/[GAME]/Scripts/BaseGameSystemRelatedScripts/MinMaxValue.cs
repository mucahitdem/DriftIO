using UnityEngine;

namespace Scripts.GameScripts
{
    [SerializeField]
    public class MinMaxValue
    {
        private float _rangeBetweenMaxAndMin;
        public float MaxVal;
        public float MinVal;

        public float RangeBetweenMaxAndMin
        {
            get
            {
                if (_rangeBetweenMaxAndMin <= 0)
                    _rangeBetweenMaxAndMin = MaxVal - MinVal;

                return _rangeBetweenMaxAndMin;
            }

            set => _rangeBetweenMaxAndMin = value;
        }
    }
}