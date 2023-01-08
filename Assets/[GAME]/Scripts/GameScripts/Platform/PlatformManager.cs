using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.BaseGameScripts.EventManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameSystemRelatedScripts.Timer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.Platform
{
    public class PlatformManager : EventSubscriber
    {
        public static Action<int> onPlatformWidened;
        
        [FoldoutGroup("Timer")]
        [SerializeField]
        private Timer timer;
        
        private int _groupIndexToRelease = 0;
        public override void SubscribeEvent()
        {
            timer.onTimerEnded += ReleaseGroup;
        }

        public override void UnsubscribeEvent()
        {
            timer.onTimerEnded -= ReleaseGroup;
        }
        
        private void ReleaseGroup()
        {
            onPlatformWidened?.Invoke(_groupIndexToRelease);
            
            IncreaseGroupIndex();
        }

        private void IncreaseGroupIndex(int countToAdd = 1)
        {
            _groupIndexToRelease += countToAdd;
        }
    }
}