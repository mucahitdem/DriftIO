using UnityEngine;

namespace Scripts.Component
{
    public interface IPhysicObj
    {
        Rigidbody Rb { get; set; }
        Collider Col { get; set; }
    }
}