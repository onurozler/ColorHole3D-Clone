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
            
            if (Mathf.Abs(newPos.x) > 10 || Mathf.Abs(newPos.z) > 10)
            {
                transformPos = transformPos.ScaleMultiplier(-0.01f);
                _holeBaseTransform.Translate(transformPos * Time.fixedDeltaTime);
            }
        }
    }
}
