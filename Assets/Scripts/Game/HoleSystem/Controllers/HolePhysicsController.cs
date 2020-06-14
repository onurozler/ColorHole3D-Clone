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

        private void OnTriggerEnter(Collider other)
        {
            var collectable = other.GetComponent<CollectableBase>();
            if (collectable != null)
            {
                collectable.Release();
            }
        }
    }
}
