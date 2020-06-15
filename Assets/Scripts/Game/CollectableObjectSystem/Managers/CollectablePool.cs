using Game.CollectableObjectSystem.Base;
using Zenject;

namespace Game.CollectableObjectSystem.Managers
{
    public class CollectablePool : MonoMemoryPool<CollectableBase>
    {
        protected override void OnCreated(CollectableBase item)
        {
            base.OnCreated(item);
            item.Initialize();
        }

        protected override void OnDespawned(CollectableBase item)
        {
            base.OnDespawned(item);
            item.Reset();
        }
    }
}
