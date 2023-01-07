using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.Animator_Control
{
    public class AnimatorManager : BaseComponent
    {
        [SerializeField]
        private AnimatorParameterController animatorParameterController;

        [field: SerializeField]
        private Animator AnimObj { get; set; }

        public override Animator AnimOfObj
        {
            get => AnimObj;
            set => AnimObj = value;
        }

        private void Awake()
        {
            animatorParameterController.CalculateKeys();
        }

        public void SetAnimator(string key)
        {
            AnimOfObj.SetTrigger(animatorParameterController.GetHashKey(key));
        }

        public void SetAnimator(string key, bool isEnabled)
        {
            AnimOfObj.SetBool(animatorParameterController.GetHashKey(key), isEnabled);
        }
    }

    [Serializable]
    public class AnimatorParameterController
    {
        private Dictionary<string, int> _animKeysAndIndexInList = new Dictionary<string, int>();

        private int _value;

        [SerializeField]
        [ShowInInspector]
        private List<AnimatorParameter> animatorParameters = new List<AnimatorParameter>();

        public void CalculateKeys()
        {
            _animKeysAndIndexInList.Clear();
            for (var i = 0; i < animatorParameters.Count; i++)
            {
                var animatorParameter = animatorParameters[i];
                animatorParameter.CalculateHashKey();
                _animKeysAndIndexInList.Add(animatorParameter.parameterName, i);
            }
        }

        public int GetHashKey(string key)
        {
            if (_animKeysAndIndexInList.TryGetValue(key, out _value))
            {
                return animatorParameters[_value].hashKey;
            }

            AddParameterName(key);
            if (_animKeysAndIndexInList.TryGetValue(key, out _value)) return animatorParameters[_value].hashKey;

            Debug.LogError("PLEASE ADD THE KEY BEFORE USING IT");
            return -1;
        }

        public void AddParameterName(string keyToAdd)
        {
            animatorParameters.Add(new AnimatorParameter(keyToAdd));
            _animKeysAndIndexInList.Add(keyToAdd, animatorParameters.Count - 1);
        }
    }

    [Serializable]
    public class AnimatorParameter
    {
        [ReadOnly]
        public int hashKey;

        public string parameterName;

        public AnimatorParameter(string parameterName)
        {
            this.parameterName = parameterName;
            CalculateHashKey();
        }

        public void CalculateHashKey()
        {
            hashKey = Animator.StringToHash(parameterName);
            Debug.LogError("HASH KEY OF " + parameterName + " is " + hashKey);
        }
    }
}