using Config;
using UnityEngine;

namespace Game.CollectableObjectSystem.Base
{
    public class CollectableBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public bool IsRelased;
        public CollectableType CollectableType;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            IsRelased = false;
        }

        public void SetValues(CollectableType collectableType, Vector3 position ,Material material)
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            CollectableType = collectableType;
            transform.position = position;
            meshRenderer.material = material;
        }

        public void Release()
        {
            gameObject.layer = GameConfig.COLLECTABLE_LAYER;
            IsRelased = true;
            _rigidbody.isKinematic = false;
        }

        public void Stop()
        {
            gameObject.layer = GameConfig.DEFAULT_LAYER;
            IsRelased = false;
        }
    }

    public enum CollectableType
    {
        GOOD,
        BAD
    }
}
