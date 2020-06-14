using System.Collections.Generic;
using Game.CollectableObjectSystem.Base;

namespace Game.CollectableObjectSystem.Managers
{
    public class CollectableManager
    {
        private List<CollectableBase> _collectableBases;

        public CollectableManager()
        {
            _collectableBases = new List<CollectableBase>();
        }

        public void Add(CollectableBase collectable)
        {
            _collectableBases.Add(collectable);
        }

        public List<CollectableBase> GetAllCollectables()
        {
            return _collectableBases;
        }
        
    }
}
