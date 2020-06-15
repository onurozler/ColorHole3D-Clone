using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace Game.HoleSystem.Controllers
{
    public class HoleMovementController
    {
        private Vector3 _firsPos;
        private Transform _holeBaseTransform;
        private Camera _camera;
        
        
        [Inject]
        private void OnInstaller(Camera camera)
        {
            _camera = camera;
            _firsPos = Vector3.zero;
        }
        
        public void Initialize(Transform holeTransform)
        {
            _holeBaseTransform = holeTransform;

            Observable.EveryFixedUpdate()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Select(_ => Input.mousePosition)
                .Subscribe(OnClicked);
            
            Observable.EveryFixedUpdate()
                .Where(_ => Input.GetMouseButton(0))
                .Select(_=> _firsPos - Input.mousePosition)
                .Subscribe(OnClicking);
        }
        
        private void OnClicked(Vector3 mousePos)
        {
            _firsPos = mousePos;
        }
        
        private void OnClicking(Vector3 newPos)
        {
            Vector3 transformPos = newPos;
            transformPos.z = newPos.y;
            transformPos.y = 0;

            transformPos = transformPos.ScaleMultiplier(0.01f);
            
            transformPos.x = Mathf.Clamp(transformPos.x, -2f, 2f);
            transformPos.z = Mathf.Clamp(transformPos.z, -2f, 2f);
            
            if ((_holeBaseTransform.position.x < 1.5f && transformPos.x < 0) || 
                (_holeBaseTransform.position.x > 5 && transformPos.x > 0))
                transformPos.x = 0;

            if ((_holeBaseTransform.position.z < -3f && transformPos.z < 0) 
                || (_holeBaseTransform.position.z > 5.25f && transformPos.z > 0))
                transformPos.z = 0;
            
            _holeBaseTransform.Translate(transformPos * Time.fixedDeltaTime);
        }
    }
}
