using Scripts.BaseGameSystemRelatedScripts.Upgrade;

namespace Scripts.GameScripts.Upgrade.Buttons
{
    public class MergeButton : BaseUpgradeButton
    {
        protected override void Awake()
        {
            base.Awake();
            upgradableData = UpgradeDataSo.UpgradesData.upgradeData.mergeData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
        }
    }
}