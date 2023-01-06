using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Upgrade
{
    [CreateAssetMenu(menuName = "Base Game/UpgradeData")]
    public class UpgradeDataSo : ScriptableObject
    {
        [HideLabel]
        public UpgradeData upgradeData;

        private static SpeedData SpeedData => UpgradesData.upgradeData.speedData;
        private static IncomeData IncomeData => UpgradesData.upgradeData.incomeData;
        private static AddData AddData => UpgradesData.upgradeData.addData;
        private static MergeData MergeData => UpgradesData.upgradeData.mergeData;

#if UNITY_EDITOR
        public void SetDataDirty()
        {
            EditorUtility.SetDirty(UpgradesData);
        }
#endif

        public static void ResetData()
        {
            SpeedData.Reset();
            IncomeData.Reset();
            AddData.Reset();
            MergeData.Reset();
        }

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static UpgradeDataSo m_UpgradeData;

        public static UpgradeDataSo UpgradesData => m_UpgradeData ??= Resources.Load<UpgradeDataSo>("UpgradeData");

        private void FindHolesDataAsset()
        {
            if (UpgradesData) return;
            Debug.LogError("HoleData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}