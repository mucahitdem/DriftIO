using System;
using Scripts.BaseGameScripts.Helper;

namespace Scripts.BaseGameScripts.Camera
{
    public class CameraManager : SingletonMono<CameraManager>
    {
        private UnityEngine.Camera _mainCamera;

        public UnityEngine.Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = UnityEngine.Camera.main;
                return _mainCamera;
            }
            set => _mainCamera = value;
        }

        protected void OnAwake()
        {
            throw new NotImplementedException();
        }
    }
}