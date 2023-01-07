using System;

namespace Scripts.BaseGameSystemRelatedScripts
{
    [Serializable]
    public class MinMaxValue
    {
        private float _rangeBetweenMaxAndMin;
      
        public float minVal;
        public float maxVal;
        
        public float RangeBetweenMaxAndMin
        {
            get
            {
                if (_rangeBetweenMaxAndMin <= 0)
                    _rangeBetweenMaxAndMin = maxVal - minVal;

                return _rangeBetweenMaxAndMin;
            }

            set => _rangeBetweenMaxAndMin = value;
        }
    }
}