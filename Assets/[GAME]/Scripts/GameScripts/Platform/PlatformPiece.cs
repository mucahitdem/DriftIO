using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class PlatformPiece : BaseComponent
    {
        private void Awake()
        {
            RigidBodyConstraintControl(RigidbodyConstraints.FreezeAll);
        }
        
        public void ReleasePiece()
        {
            RigidBodyConstraintControl(RigidbodyConstraints.None);
        }

        private void RigidBodyConstraintControl(RigidbodyConstraints constraints)
        {
            Rb.constraints = constraints;
        }
    }
}