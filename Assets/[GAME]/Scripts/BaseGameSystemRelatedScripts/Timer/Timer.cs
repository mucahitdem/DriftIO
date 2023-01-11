using System;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Timer
{
    [Serializable]
    public class Timer : MonoBehaviour
    {
        public Action onTimerEnded;

        [SerializeField]
        private TimerVariables timerVariables;
        
        [Title("Private Variables")]
        private float _timerValue;
        public float TimerValue
        {
            get => _timerValue;
            set
            {
                if (Math.Abs(value - _timerValue) > .0001f)
                {
                    _timerValue = value;

                    if (_timerValue <= 0)
                    {
                        onTimerEnded?.Invoke();
                        
                        if (timerVariables.isRepeating)
                        {
                            ResetTimer();
                            return;
                        }
                        
                        RemoveTimerFromManager();
                    }
                }
            }
        }

        private void Awake()
        {
            ResetTimer();
            if(!timerVariables.startManually)
                AddTimerToManager();
        }

        public void StartTimer()
        {
            ResetTimer();
            AddTimerToManager();
        }

        // add pause timer method
        
        public void StopTimer()
        {
            TimerManager.Instance.RemoveTimer(this);
        }
        
        private void AddTimerToManager()
        {
            TimerManager.Instance.AddNewTimer(this);
        }

        private void RemoveTimerFromManager()
        {
            TimerManager.Instance.RemoveTimer(this);
        }

        private void ResetTimer()
        {
            TimerValue = timerVariables.timerValue;
        }
    }

    [Serializable]
    public class TimerVariables
    {
        [Title("Timer")]
        public float timerValue;
        
        [Title("Repeat")]
        public bool isRepeating;

        [Title("Starting Timer")]
        public bool startManually;
    }
}