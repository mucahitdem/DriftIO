using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.Rope
{
    public class RopeWithLineRenderer : BaseComponent, IRope
    {
        [SerializeField]
        private Transform[] lineRendPoints;

        private int _lineRendPointCount;
        
        private void Awake()
        {
            _lineRendPointCount = lineRendPoints.Length;
            LineRend.positionCount = _lineRendPointCount;
        }

        public void UpdateRope()
        {
            for (int i = 0; i < lineRendPoints.Length; i++)
            {
                LineRend.SetPosition(i, lineRendPoints[i].position);
            }
        }
    }
}