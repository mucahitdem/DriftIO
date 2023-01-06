﻿using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Helper
{
    public class TimeManager : MonoBehaviour
    {
        private int _index;

        [SerializeField]
        private List<float> timeScales = new List<float>();

        public void ChangeTimeScale()
        {
            IncreaseIndex();
            Time.timeScale = timeScales[_index];
        }

        private void IncreaseIndex()
        {
            _index++;
            if (_index >= timeScales.Count) _index = 0;
        }
    }
}