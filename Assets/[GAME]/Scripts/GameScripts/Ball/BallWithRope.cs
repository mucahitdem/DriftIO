using Scripts.GameScripts.Rope;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.Ball
{
    public class BallWithRope : BaseBall
    {
        [ReadOnly]
        [ShowInInspector]
        private IRope _rope;
        
        protected override void Awake()
        {
            base.Awake();
            _rope = GetComponent<IRope>();
        }
        
        public override void OnUpdate()
        {
            _rope?.UpdateRope();
        }
        
        public override void OnEnable()
        {
            base.OnEnable();
            _rope.EnableRope();
        }

        public override void OnDisable()
        {
            base.OnDisable();
            _rope.DisableRope();
        }
    }
}