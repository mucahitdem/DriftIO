using Scripts.BaseGameSystemRelatedScripts.Upgrade;
using Scripts.GameScripts.Grid;

namespace Scripts.GameScripts.Upgrade.Buttons
{
    public class AddButton : BaseUpgradeButton
    {
        protected override void Awake()
        {
            base.Awake();
            upgradableData = UpgradeDataSo.UpgradesData.upgradeData.addData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            GridManager.gridsFilled += OnGridsFilled;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            GridManager.gridsFilled -= OnGridsFilled;
        }
        
        private void OnGridsFilled()
        {
            ButtonControl(false);
        }
    }
}