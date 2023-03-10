using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Scripts.BaseGameScripts.Control
{
    public class CalculateDeltaMouse
    {
        [ReadOnly]
        public Vector2 deltaMousePos;
        [ReadOnly]
        public Vector2 mouseStartPos;

        private Vector2 _currentMousePos;

        public void CalculateDeltaMousePos()
        {
            _currentMousePos = UnityEngine.Input.mousePosition;
            deltaMousePos = new Vector2(_currentMousePos.x - mouseStartPos.x, _currentMousePos.y - mouseStartPos.y); // how much mouse dragged
        }
        
        public void ResetValues()
        {
            mouseStartPos = UnityEngine.Input.mousePosition;
        }
    }
}