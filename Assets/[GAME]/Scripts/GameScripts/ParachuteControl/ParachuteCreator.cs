using Scripts.BaseGameScripts.EventManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameSystemRelatedScripts.Timer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts.ParachuteControl
{
    public class ParachuteCreator : EventSubscriber
    {
        [SerializeField]
        private Timer timer;
        
        [SerializeField]
        private float radius;
        
        [SerializeField]
        private float createHeight;

        [SerializeField]
        private Parachute parachute;
        

        public override void SubscribeEvent()
        {
            timer.onTimerEnded += CreateParachute;
            GameManager.Instance.PlatformRadiusController.onPlatformRadiusChanged += UpdateRadius;
        }

        public override void UnsubscribeEvent()
        {
            timer.onTimerEnded -= CreateParachute;
            GameManager.Instance.PlatformRadiusController.onPlatformRadiusChanged -= UpdateRadius;
        }

        private void UpdateRadius(float newRadius)
        {
            radius = newRadius;
        }
        
        private void CreateParachute()
        {
            Parachute createdParachute = Instantiate(parachute);//GlobalReferences.Instance.poolManager.parachutePool.PullObj();
            createdParachute.TransformOfObj.position = GenerateRandomPosition();
        }

        private Vector3 GenerateRandomPosition()
        {
            float randomAngle = Random.Range(0f, 360f);
            float randomRadius = Random.Range(0f, radius);
            return new Vector3(randomRadius * Mathf.Cos(randomAngle), 
                                    createHeight, 
                                        randomRadius * Mathf.Sin(randomAngle)); 
        }
    }
}