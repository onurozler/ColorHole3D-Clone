using System;
using UnityEngine;

namespace Game.CollectableObjectSystem.Base
{
    public class CollectableBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public CollectableType CollectableType;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
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
            _rigidbody.isKinematic = false;
        }
    }

    public enum CollectableType
    {
        GOOD,
        BAD
    }
}
