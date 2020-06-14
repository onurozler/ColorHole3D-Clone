using System;
using Config;
using Game.CollectableObjectSystem.Base;
using UnityEngine;

namespace Game.HoleSystem.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class HolePhysicsController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        
        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }

        private void OnTriggerStay(Collider other)
        {
            var collectable = other.GetComponent<CollectableBase>();
            if (collectable != null && !collectable.IsRelased)
            {
                collectable.Release();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var collectable = other.GetComponent<CollectableBase>();
            if (collectable != null && collectable.IsRelased)
            {
                collectable.Stop();
            }
        }
    }
}
