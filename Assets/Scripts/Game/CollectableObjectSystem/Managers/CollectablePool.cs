using System.Collections.Generic;
using Game.CollectableObjectSystem.Base;
using Zenject;

namespace Game.CollectableObjectSystem.Managers
{
    public class CollectablePool : MonoMemoryPool<CollectableBase>
    {
        private List<CollectableBase> _activePool;
        
        protected override void OnCreated(CollectableBase item)
        {
            base.OnCreated(item);
            item.Initialize();
        }

        protected override void OnSpawned(CollectableBase item)
        {
            base.OnSpawned(item);
            if(_activePool == null) _activePool = new List<CollectableBase>();
            _activePool.Add(item);
        }

        protected override void OnDespawned(CollectableBase item)
        {
            base.OnDespawned(item);
            item.Reset();
        }

        public void ResetPool()
        {
            if(_activePool == null || _activePool.Count <= 0)
                return;
            
            foreach (var poolItem in _activePool)
            {
                OnDespawned(poolItem);
            }
            _activePool.Clear();
        }
    }
}
