using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class ShieldCreator : MonoBehaviour
    {
        private List<Transform> _allShields = new List<Transform>();
        
        [SerializeField]
        private GameObject shield;

        [SerializeField]
        private Transform parent;
        
        [SerializeField]
        private int count;

        [SerializeField]
        private float radius;

        [SerializeField]
        private float height;
        
        private float _currentAngle = 0;
        
        [Button]
        private void CreateShield()
        {
            float angleToAdd = 360f / (float)count;
            DebugHelper.LogRed("ANGLE TO ADD : " + angleToAdd);
            
            for (int i = 0; i < count; i++)
            {
                Vector3 pos = new Vector3(Mathf.Cos(_currentAngle) * radius, 0, Mathf.Sin(_currentAngle) * radius);
                Transform shieldCreated = Instantiate(shield, parent).transform;
                shieldCreated.position = pos;
                shieldCreated.LookAt(Vector3.zero, Vector3.up);
                
                _allShields.Add(shieldCreated);
                
                _currentAngle += angleToAdd;
                DebugHelper.LogRed("CURRENT ANGLE : " + _currentAngle);
            }   
        }

        [Button]
        private void ClearShields()
        {
            for (int i = 0; i < _allShields.Count; i++)
            {
                DestroyImmediate(_allShields[i].gameObject);
            }
            _allShields.Clear();
        }
    }
}