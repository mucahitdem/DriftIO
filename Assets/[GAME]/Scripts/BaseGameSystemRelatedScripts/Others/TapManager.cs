using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.GameScripts.Upgrade
{
    public class TapManager : MonoBehaviour
    {
        private float _timer = 0.5f;

        [ReadOnly]
        public float factor = 1;

        [SerializeField]
        private float maxFactor = 5f;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
        }

        private void Unsubscribe()
        {
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !TouchOnUI())
            {
                _timer = 0.5f;
                factor = maxFactor;
            }
            else
            {
                _timer -= Time.deltaTime;
                if (_timer < 0) factor = 1;
            }
        }

        private void OnTap()
        {
            _timer = 0.5f;
            factor = maxFactor;
        }

        private bool TouchOnUI()
        {
            if (!EventSystem.current) return false;
            var eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = Input.mousePosition;

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count != 0;
        }
    }
}