using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Timer
{
    public class TimerManager : SingletonMono<TimerManager>
    {
        private List<Timer> _timerList = new List<Timer>();

        protected override void OnAwake()
        {
            
        }
        
        public void AddNewTimer(Timer timer)
        {
            DebugHelper.LogGreen("TIMER ADDED : " + timer.name);
            _timerList.Add(timer);    
        }

        public void RemoveTimer(Timer timer)
        {
            _timerList.Remove(timer);
        }

        private void Update()
        {
            UpdateTimers();
        }

        private void UpdateTimers()
        {
            for (int i = 0; i < _timerList.Count; i++)
            {
                _timerList[i].TimerValue -= Time.deltaTime;
            }
        }
    }
}