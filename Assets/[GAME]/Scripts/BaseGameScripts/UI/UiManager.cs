using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BaseGameScripts.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private List<UiItem> screens = new List<UiItem>();

        [SerializeField]
        private List<UiItem> uiItems = new List<UiItem>();

        public void ShowScreen(string uiItemId)
        {
            ShowOneHideRest(screens, uiItemId);
        }

        private void ShowOneHideRest(List<UiItem> itemGroup, string uiItemId)
        {
            for (var i = 0; i < itemGroup.Count; i++)
            {
                var currentUi = itemGroup[i];

                currentUi.Go.SetActive(uiItemId == currentUi.id);
            }
        }

        public void ShowUi(string uiId)
        {
            for (var i = 0; i < uiItems.Count; i++)
            {
                var currentUi = screens[i];

                if (uiId == currentUi.id)
                    currentUi.Go.SetActive(true);
            }
        }

        public void ShowMultipleUis(params string[] ids) // not recommend to use because it is too slow
        {
            for (var i = 0; i < uiItems.Count; i++)
            {
                var currentUi = screens[i];

                for (var j = 0; j < ids.Length; j++)
                {
                    var itemId = ids[j];

                    if (itemId == currentUi.id) currentUi.Go.SetActive(true);
                }
            }
        }
    }
}