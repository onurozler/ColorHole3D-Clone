using Config;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.HoleSystem.Controllers
{
    public class HoleMovementController
    {
        private Transform _holeBaseTransform;
        private Camera _camera;
        private float _movementX;
        private float _movementZ;
        
        [Inject]
        private void OnInstaller(Camera camera)
        {
            _camera = camera;
        }
        
        public void Initialize(Transform holeTransform)
        {
            _holeBaseTransform = holeTransform;
            
            Observable.EveryFixedUpdate()
                .Where(_ => Input.GetMouseButton(0))
                .Select(_=> Input.mousePosition)
                .Subscribe(OnClicking);
        }

        private void OnClicking(Vector3 newPos)
        {
            _movementX = GameConfig.HoleSpeedX * -Input.GetAxis("Mouse X");
            _movementZ = GameConfig.HoleSpeedZ * -Input.GetAxis("Mouse Y");

            _holeBaseTransform.Translate(_movementX,0,_movementZ);
            _holeBaseTransform.position = new 
                Vector3(Mathf.Clamp(_holeBaseTransform.position.x,1.5f,5),0.1f, 
                    Mathf.Clamp(_holeBaseTransform.position.z,-3f,5.25f));
        }
    }
}
