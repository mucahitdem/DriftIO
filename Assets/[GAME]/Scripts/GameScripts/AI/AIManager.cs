using System;
using System.Collections;
using DG.Tweening;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameSystemRelatedScripts.Timer;
using Scripts.GameScripts.SO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts.AI
{
    /// <summary>
    /// - Try to stay in arena (we can calculate that with radius)
    /// 
    /// - Opponent Find algorithm : find nearest and preferly in front of us
    /// 
    /// - Attack : After finding opponent to attack rotate car (it is important radius from back of car to ball behind us)
    /// - Defend : Try to avoid attacks -- if there is a rotating car in range of X, go away or you can also rotate to attack as a defense
    /// 
    /// - Be aware of parachutes 
    /// </summary>
    public class AiManager : BasePlayerAndAi
    {
        [SerializeField]
        private Timer timerForSearchOpponents;
        
        private TryToStayOnPlatform _tryToStayOnPlatform;
        private FindNearestOpponentData _findNearestOpponentData;
        private FindNearestOpponents _nearestOpponents;
        private FindNearestOpponents NearestOpponents
        {
            get
            {
                if (_nearestOpponents == null)
                {
                    _nearestOpponents = new FindNearestOpponents(_findNearestOpponentData);
                }
                return _nearestOpponents;
            }
        }
        
        private float _turnSpeed;

        protected override void Awake()
        {
            base.Awake();
            UpdateVariables();
            OnPlatformRadiusChanged(50);
        }

        private void UpdateVariables()
        {
            _turnSpeed = InternalGameDataSo.InternalGameData.gameData.turnSpeed;

            _findNearestOpponentData = new FindNearestOpponentData();
            _findNearestOpponentData.transformObj = TransformOfObj;
            _findNearestOpponentData.GetVariables();
            
            _tryToStayOnPlatform = new TryToStayOnPlatform();
            _tryToStayOnPlatform.GetVariables();
        }

        private void Update()
        {
            if(!canControl)
                return;
                
            if (_tryToStayOnPlatform.CheckIfGoingOutOfArena(TransformOfObj))
            {
                LookAt(null, Vector3.zero);
            }
            else 
            {
                if(NearestOpponents == null)
                    return;
                
                if (NearestOpponents.OpponentIsCloseEnough())
                {
                    Drift(IsOpponentAtRight());
                }
                else 
                {
                    LookAt(NearestOpponents.GetNearestOpponent().TransformOfObj);
                }
            }
        }

        #region Subs

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            GameManager.Instance.PlatformRadiusController.onPlatformRadiusChanged += OnPlatformRadiusChanged;
            GameManager.Instance.opponentRemoved += NearestOpponents.ResetData;
            
            timerForSearchOpponents.onTimerEnded += NearestOpponents.GetRandomOpponent;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            if (GameManager.Instance)
            {
                GameManager.Instance.PlatformRadiusController.onPlatformRadiusChanged -= OnPlatformRadiusChanged;
                GameManager.Instance.opponentRemoved += NearestOpponents.ResetData;
            }
                
            timerForSearchOpponents.onTimerEnded -= NearestOpponents.GetRandomOpponent;

        }

        #endregion
        
        private void OnPlatformRadiusChanged(float newRadius)
        {
           _tryToStayOnPlatform.OnPlatformRadiusChanged(newRadius);
        }
        
        private void LookAt(Transform target = null, Vector3 position = default)
        {
            Vector3 dir;
            if(target)
                dir = target.position - TransformOfObj.position;
            else
                dir = position - TransformOfObj.position;
            
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(TransformOfObj.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
            TransformOfObj.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
            
        private void Drift(bool turnToRight)
        {
            Vector3 wayToTurn = turnToRight ? Vector3.up : -Vector3.up;
            TransformOfObj.eulerAngles += wayToTurn * (200 * Time.deltaTime);
        }

        private bool IsOpponentAtRight()
        {
            return GetOpponentsDirectionAccordingToMe() == Way.Right;
        }
        
        private Way GetOpponentsDirectionAccordingToMe()
        {
            return GetGivenPointAtWhichDirection.DirectionOfPoint(TransformOfObj.position, TransformOfObj.forward,
                NearestOpponents.GetNearestOpponent().TransformOfObj.position);
        } 
    }

    [Serializable]
    public class TryToStayOnPlatform
    {
        [SerializeField]
        private float maxPercentageOfRadiusToGo = 70;
        
        private float _distance;
        private float _platformHalfRadius;
        private float _calculatedRadiusForAi;

        public void GetVariables()
        {
            GameData gameData = InternalGameDataSo.InternalGameData.gameData;
            maxPercentageOfRadiusToGo = gameData.maxPercentageAiCanBeAwayOnArenaCenter;
        }
        
        public bool CheckIfGoingOutOfArena(Transform transformObj) // on update
        {
            _distance = (transformObj.position - Vector3.zero).magnitude;
            if (_distance > _calculatedRadiusForAi)
            {
                return true;
            }

            return false;
        }

        public void OnPlatformRadiusChanged(float newRadius)
        {
            _platformHalfRadius = (newRadius / 2f);
            _calculatedRadiusForAi = _platformHalfRadius * maxPercentageOfRadiusToGo / 100f;
        }
    }
    public class FindNearestOpponents
    {
        private BasePlayerAndAi _nearestOpponent;
        private float _nearestDistance;
        private FindNearestOpponentData _findNearestOpponentData;
        public FindNearestOpponents(FindNearestOpponentData findNearestOpponentData)
        {
            _findNearestOpponentData = findNearestOpponentData;
            _nearestDistance = Mathf.Infinity; 
        }

        public void ResetData()
        {
            _nearestOpponent = null;
            _nearestDistance = Mathf.Infinity;
            GetRandomOpponent();
        }

        public void GetRandomOpponent()
        {
            for (int i = 0; i < 20; i++) // we can make it more cleverly
            {
                int randomNumber = Random.Range(0, GameManager.Instance.allOpponents.Count);
                BasePlayerAndAi currentOpponent = GameManager.Instance.allOpponents[randomNumber];
                
                if(currentOpponent.TransformOfObj == _findNearestOpponentData.transformObj)
                    continue;
                _nearestOpponent = currentOpponent;
            }
        }
        
        public void FindNearestOpponent() // update every X seconds - 1 or 2 is enough
        {
            for (int i = 0; i < GameManager.Instance.allOpponents.Count; i++)
            {
                BasePlayerAndAi currentOpponent = GameManager.Instance.allOpponents[i];
                
                if(currentOpponent.TransformOfObj == _findNearestOpponentData.transformObj)
                    continue;

                var distance = Vector3.Distance(currentOpponent.TransformOfObj.position, _findNearestOpponentData.transformObj.position);
                if (distance < _nearestDistance)
                {
                    _nearestDistance = distance;
                    _nearestOpponent = currentOpponent;
                }
            }

            if (_nearestOpponent == null)
                Time.timeScale = 0f;
        }

        public BasePlayerAndAi GetNearestOpponent()
        {
            if (!_nearestOpponent)
            {
                GetRandomOpponent();
                return _nearestOpponent;
            }
               
            return _nearestOpponent;
        }
        
        public bool OpponentIsCloseEnough()
        {
            var distance = Vector3.Distance(GetNearestOpponent().TransformOfObj.position, _findNearestOpponentData.transformObj.position);
            _nearestDistance = distance;
            
            if (_nearestDistance <=_findNearestOpponentData.ballHitRadius)
            {
                return true;
            }

            return false;
        }
    }
    [Serializable]
    public class FindNearestOpponentData
    {
        [HideInInspector]
        public Transform transformObj;
        public float updateNearestOpponentEveryXSecond;

        public float ballHitRadius;

        public void GetVariables()
        {
            GameData gameData = InternalGameDataSo.InternalGameData.gameData;
            updateNearestOpponentEveryXSecond = gameData.updateNearestOpponentEveryXSecond;
            ballHitRadius = gameData.ballHitRadius;
        }
    }

    // public class FindAvailableDropBoxes
    // {
    //     
    //     public void OnParachuteCreated(Vector3 pos)
    //     {
    //         
    //     }
    // }
}