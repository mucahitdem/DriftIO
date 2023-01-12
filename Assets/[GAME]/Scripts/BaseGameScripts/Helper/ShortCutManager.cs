using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    public class ShortCutManager : MonoBehaviour
    {
        private ShortCutData _shortCutData;
        public List<ShortCutData> keycodes = new List<ShortCutData>();

        #if UNITY_EDITOR
        private void Update()
        {
            for (var i = 0; i < keycodes.Count; i++)
            {
                _shortCutData = keycodes[i];
                if (Input.GetKeyDown(_shortCutData.keyCode)) _shortCutData.unityEvent?.Invoke();
            }
        }
        #endif
    }

    [Serializable]
    public class ShortCutData
    {
        [FoldoutGroup("Data")]
        [GUIColor(0.3f, 0.8f, 0.8f)]
        public KeyCode keyCode;

        [FoldoutGroup("Data")]
        [GUIColor(0.3f, 0.8f, 0.8f)]
        public UnityEvent unityEvent;
    }
}