using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Scripts.State._Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.State
{
    public class GameStateManager : MonoBehaviour
    {
        [ShowInInspector]
        [ReadOnly]
        private IGameState _currentState;

        [Title("Private Variables")]
        private bool _firstState;

        private int _indexInList;
        public List<IGameState> states = new List<IGameState>();

        private void Awake()
        {
            AddStates();
        }

        private void AddStates()
        {
            var subClasses = AssemblyManager.GetSubClassesOfType(typeof(GameState));

            for (var i = 0; i < subClasses.Count; i++)
            {
                var currentType = subClasses[i];

                var stateBehaviour = (IGameState) gameObject.AddComponent(currentType);
                states.Add(stateBehaviour);

                if (!_firstState)
                {
                    _firstState = true;
                    _currentState = stateBehaviour;
                }
            }
        }


        /// <summary>
        ///     Go to next state from list of states
        /// </summary>
        public void NextState()
        {
            IncreaseIndex();

            _currentState = GetStateWithIndex();
            _currentState.InitState();
        }

        /// <summary>
        ///     Sub level is number after "_" in the Game State name.
        ///     For Example GameState_03_0. Here "0" after "_" represent sub level
        /// </summary>
        /// <param name="subLevel"></param>
        public void NextState(int subLevel)
        {
        }

        /// <summary>
        ///     If you don't know sub level, see "NextState(int subLevel)" description first.
        ///     "isSucceeded" represent win/lose situation of current state. If sub level is "0", it is fail. Else if it is "1", it
        ///     is success
        /// </summary>
        /// <param name="isSucceeded"></param>
        public void NextState(bool isSucceeded)
        {
        }

        private void IncreaseIndex()
        {
            _indexInList++;
        }

        private IGameState GetStateWithIndex()
        {
            try
            {
                return states[_indexInList];
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}