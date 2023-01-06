using Scripts.BaseGameScripts.Camera;
using UnityEngine;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class CoinCollectAnim : MonoBehaviour
    {
        [SerializeField]
        private RectTransform coinIconOnScreen;

        public void Create(Vector3 createPositionOn3d)
        {
            var coinCreated = GlobalReferences.Instance.poolManager.coinPool.PullObj();
            
            coinCreated.TransformOfObj.position = CameraManager.Instance.MainCamera.WorldToScreenPoint(createPositionOn3d);
            coinCreated.MoveToCounter(coinIconOnScreen.position);
        }
    }
}