using System;
using UnityEngine;

namespace Game.CollectableObjectSystem.Base
{
    public class CollectableBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public CollectableType CollectableType;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(CollectableType collectableType)
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            CollectableType = collectableType;
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
