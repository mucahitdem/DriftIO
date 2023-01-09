﻿using System;
using Scripts.BaseGameScripts.Control;
using Scripts.GameScripts.Rope;
using UnityEngine;

namespace Scripts.GameScripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private IControl _control;
        private IMovement _movement;
        private IRope _rope;
        
        private void Awake()
        {
            _control = GetComponent<IControl>();
            _movement = GetComponent<IMovement>();
            _rope = GetComponent<IRope>();
        }
        
        private void Update()
        {
            _rope?.UpdateRope();
        }
        
        
        private void FixedUpdate()
        {
            _movement?.Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Defs.TAG_POWER_UP))
            {
                
            }
        }
    }
}