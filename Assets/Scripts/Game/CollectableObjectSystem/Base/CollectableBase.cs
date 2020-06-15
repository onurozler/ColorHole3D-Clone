using Config;
using UnityEngine;

namespace Game.CollectableObjectSystem.Base
{
    public class CollectableBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _firstVelocity;
        private Vector3 _firstRotation;

        public bool IsRelased;
        public CollectableType CollectableType;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _firstVelocity = Vector3.zero;
            _firstRotation = Vector3.zero;
            Reset();
        }

        public void SetValues(CollectableType collectableType, Vector3 position ,Material material)
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            CollectableType = collectableType;
            transform.position = position;
            meshRenderer.material = material;
        }

        public void Release(Vector3 releaseTowards)
        {
            gameObject.layer = GameConfig.COLLECTABLE_LAYER;
            IsRelased = true;
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce((releaseTowards - transform.position) * GameConfig.FORCE_TO_HOLE);
        }

        public void Stop()
        {
            gameObject.layer = GameConfig.DEFAULT_LAYER;
            _rigidbody.velocity = _firstVelocity;
            IsRelased = false;
        }
        
        public void Reset()
        {
            IsRelased = false;
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = _firstVelocity;
            transform.eulerAngles = _firstRotation;
        }
    }

    public enum CollectableType
    {
        GOOD,
        BAD
    }
}
