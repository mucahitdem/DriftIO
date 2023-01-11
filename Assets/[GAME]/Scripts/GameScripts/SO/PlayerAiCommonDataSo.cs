using UnityEngine;

namespace Scripts.GameScripts.SO
{
    [CreateAssetMenu(fileName = "Opponent Data", menuName = "DriftIO/Opponent Data", order = 0)]
    public class PlayerAiCommonDataSo : ScriptableObject
    {
        public Material carMaterial;
        public Material ballMaterial;
    }
}