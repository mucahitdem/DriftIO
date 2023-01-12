using System;
using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.SO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts
{
    public class StickerManager : BaseComponent
    {
        private GameData _gameData;

        [SerializeField]
        private Image image;

        [SerializeField]
        private BasePlayerAndAi basePlayerAndAi;

        private bool _isEnabled;
        private void Awake()
        {
            image.enabled = false;
            _gameData = InternalGameDataSo.InternalGameData.gameData;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            _isEnabled = true;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            _isEnabled = false;
        }

        private void Update()
        {
            if(_isEnabled)
                transform.position = basePlayerAndAi.TransformOfObj.position + Vector3.up * 5f;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            basePlayerAndAi.onGetHit += GetRandomBadSticker;
            basePlayerAndAi.onHitOtherPlayer += GetRandomGoodSticker;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            basePlayerAndAi.onGetHit -= GetRandomBadSticker;
            basePlayerAndAi.onHitOtherPlayer -= GetRandomGoodSticker;
        }

        private void GetRandomGoodSticker()
        {
            image.enabled = true;
            int randomVal = Random.Range(0, _gameData.goodEmojis.Count);
            image.sprite = _gameData.goodEmojis[randomVal];
            ClearSticker();
        }
        
        private void GetRandomBadSticker()
        {
            image.enabled = true;
            int randomVal = Random.Range(0, _gameData.badEmojis.Count);
            image.sprite = _gameData.badEmojis[randomVal];
            ClearSticker();
        }

        private void ClearSticker()
        {
            DOVirtual.DelayedCall(1, ()=> image.enabled = false);
        }
    }
}