using DG.Tweening;
using UnityEngine;

namespace Scripts.GameScripts.Camera
{
    public class CameraManager : MonoBehaviour
    {
        public enum HorizontalFollow
        {
            None,
            Instant,
            Gradually
        }

        [Header("Follow Settings")]
        public bool follow;

        [Header("Follow Method Variables")]
        [SerializeField]
        Transform target;

        [HideInInspector]
        public float speed = 3f;

        [Header("Horizontal Follow")]
        public HorizontalFollow horizontalFollowType;

        public float horizontalFollowLerpMult;
        public float horizontalClampVal;


        private Vector3 _newPos = Vector3.zero;
        private Vector3 _vel = Vector3.zero;
        private float _temporaryXVal;

        [HideInInspector]
        public Vector3 offset;


        [Header("Camera")]
        private UnityEngine.Camera _cam;

        void Awake()
        {
            follow = true;
            OffsetCalculate();
            _cam = GetComponent<UnityEngine.Camera>();
            _newPos.x = transform.position.x;
        }

        void LateUpdate()
        {
            if (follow)
            {
                FollowMethod();
            }
        }

        void FollowMethod()
        {
            if (target)
            {
                NewPosCalculator();
                transform.position = Vector3.SmoothDamp(transform.position, _newPos, ref _vel, speed * Time.deltaTime);
            }
        }

        private Vector3 NewPosCalculator()
        {
            NewPosX();
            var position = target.position;
            _newPos.y = position.y + offset.y;
            _newPos.z = position.z + offset.z;
            return _newPos;
        }

        private float NewPosX()
        {
            switch (horizontalFollowType)
            {
                case HorizontalFollow.None:
                    return _newPos.x;

                case HorizontalFollow.Instant:
                    _newPos.x = target.position.x + offset.x;
                    return _newPos.x;

                case HorizontalFollow.Gradually:
                    _newPos.x = target.position.x + offset.x;
                    _newPos.x = Mathf.Clamp(_newPos.x, -horizontalClampVal, horizontalClampVal);
                    _temporaryXVal = Mathf.Lerp(transform.position.x, _newPos.x,
                        horizontalFollowLerpMult * Time.deltaTime);
                    _newPos.x = _temporaryXVal;
                    return _newPos.x;
            }

            return _newPos.x;
        }

        private Vector3 OffsetCalculate()
        {
            var position = target.position;
            offset = transform.position - position;
            _newPos.y = position.y + offset.y;
            //Debug.Log("OFFSET :::: " + newPos);
            return offset;
        }

        public void CameraShake()
        {
            //cam.DOShakePosition(.1f, .2f).SetId(1);
            _cam.DOShakeRotation(.1f, 3.5f, 100).SetEase(Ease.Linear).SetId(2);
        }

        public void ReTarget(Transform desiredObj)
        {
            target = desiredObj /*.GetComponent<Rigidbody>()*/;
            OffsetCalculate();
        }

        public void LookAtTarget(Transform desiredObj)
        {
            transform.DOLookAt(desiredObj.position, .3f);
        }
    }
}