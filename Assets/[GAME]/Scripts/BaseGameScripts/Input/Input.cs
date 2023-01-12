﻿using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.BaseGameScripts.Input
{
    public abstract class Input : BaseComponent
    {
        private bool _isTouchScreen;

        public virtual void Start()
        {
            TouchSettings();
        }

        private void Update()
        {
            UpdateInput();
        }

        private void TouchSettings()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                _isTouchScreen = true;
                UnityEngine.Input.multiTouchEnabled = false;
            }
            else
            {
                _isTouchScreen = false;
            }
        }

        private void UpdateInput()
        {
            if (_isTouchScreen)
                TouchControl();
            else
                MouseControl();
        }

        private void MouseControl()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
                OnTapDown();
            else if (UnityEngine.Input.GetMouseButton(0))
                OnTapHold();
            else if (UnityEngine.Input.GetMouseButtonUp(0)) 
                OnTapUp();
        }

        private void TouchControl()
        {
            if(UnityEngine.Input.touchCount <= 0)
                return;
            switch (UnityEngine.Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    OnTapDown();
                    break;

                case TouchPhase.Moved:
                    OnTapHold();
                    break;

                case TouchPhase.Stationary:
                    OnTapHoldAndNotMove();
                    break;

                case TouchPhase.Ended:
                    OnTapUp();
                    break;
            }
        }

        protected virtual void OnTapDown()
        {
            if(TouchOnUI())
                return;
        }

        protected abstract void OnTapHold();

        protected abstract void OnTapHoldAndNotMove();

        protected abstract void OnTapUp();
        
        
        private bool TouchOnUI()
        {
            if (!EventSystem.current) 
                return false;
            var eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = UnityEngine.Input.mousePosition;

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count != 0;
        }
    }
}