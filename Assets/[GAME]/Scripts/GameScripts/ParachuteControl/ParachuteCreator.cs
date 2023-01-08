using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.EventManagement;
using Scripts.BaseGameSystemRelatedScripts.Timer;
using UnityEngine;
using UnityEngine.AI;
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
        

        public override void SubscribeEvent()
        {
            timer.onTimerEnded += CreateParachute;
        }

        public override void UnsubscribeEvent()
        {
            timer.onTimerEnded -= CreateParachute;
        }
        
        private void CreateParachute()
        {
            Parachute parachute = GlobalReferences.Instance.poolManager.parachutePool.PullObj();
            parachute.TransformOfObj.position = GenerateRandomPosition();
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