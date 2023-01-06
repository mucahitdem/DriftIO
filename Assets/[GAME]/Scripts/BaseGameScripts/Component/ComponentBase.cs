using Scripts.BaseGameScripts.EventManagement;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.BaseGameScripts.Component
{
    public class ComponentBase : EventSubscriber
    {
        private Collider _col;

        private GameObject _go;

        private LineRenderer _lineRenderer;

        private Rigidbody _rb;

        private RectTransform _rect;
        private Transform _transformOfObj;

        protected Animator Anim;

        public Transform TransformOfObj
        {
            get
            {
                if (!_transformOfObj)
                    _transformOfObj = transform;
                return _transformOfObj;
            }
            set => _transformOfObj = value;
        }

        public GameObject Go
        {
            get
            {
                if (!_go)
                    _go = gameObject;
                return _go;
            }
            set => _go = value;
        }

        protected Rigidbody Rb
        {
            get
            {
                if (!_rb)
                    _rb = GetComponent<Rigidbody>();
                return _rb;
            }
            set => _rb = value;
        }

        public Collider Col
        {
            get
            {
                if (!_col)
                    _col = GetComponent<Collider>();
                return _col;
            }
            set => _col = value;
        }

        public RectTransform Rect
        {
            get
            {
                if (!_rect)
                    _rect = GetComponent<RectTransform>();
                return _rect;
            }
            set => _rect = value;
        }

        public virtual Animator AnimOfObj
        {
            get
            {
                if (!Anim)
                    Anim = GetComponent<Animator>();

                return Anim;
            }
            set => Anim = value;
        }

        protected LineRenderer LineRend
        {
            get
            {
                if (!_lineRenderer) _lineRenderer = GetComponent<LineRenderer>();
                return _lineRenderer;
            }
            set => _lineRenderer = value;
        }


        public override void SubscribeEvent()
        {
        }

        public override void UnsubscribeEvent()
        {
        }
    }
}