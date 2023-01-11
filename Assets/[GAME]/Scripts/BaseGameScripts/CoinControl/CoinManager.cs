using System;
using System.Collections;
using BayatGames.SaveGameFree;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoad;
using UnityEngine;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class CoinManager : SingletonMono<CoinManager>, ISaveAndLoad
    {
        public static Action<float> onCoinCountChanged;

        private float TotalCoins { get; set; }
        
        
        protected override void OnAwake()
        {
            Load();
            onCoinCountChanged?.Invoke(TotalCoins);
        }

        private void OnDisable()
        {
            Save();
        }


        #region Save And Load
        
        public void Save()
        {
            SaveGame.Save("totalCoinCount", TotalCoins);
        }

        public void Load()
        {
            TotalCoins = SaveGame.Load("totalCoinCount", TotalCoins);
            Debug.Log("TOTAL COIN COUNT LOADED: " + TotalCoins);
        }
        

        #endregion

        public void AddCoin(float coinToAdd)
        {
            TotalCoins += coinToAdd;
            onCoinCountChanged?.Invoke(TotalCoins);
        }
        
        public void SpendCoin(float coinToSpend)
        {
            TotalCoins -= coinToSpend;
            onCoinCountChanged?.Invoke(TotalCoins);
        }

        public bool CheckIfYouHaveEnoughCoin(float coinCountToCheck)
        {
            return coinCountToCheck <= TotalCoins;
        }
    }
}