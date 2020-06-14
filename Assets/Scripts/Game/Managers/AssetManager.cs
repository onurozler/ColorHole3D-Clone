using System;
using System.Collections.Generic;
using System.Linq;
using Game.CollectableObjectSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class AssetManager
    {
        private const string MATERIAL_PREFIX = "_Material";
        private List<Material> _materials;
        
        [Inject]
        private void OnInstaller(List<Material> materials)
        {
            _materials = materials;
        }

        public Material GetCollectableMaterial(CollectableType collectableType)
        {
            return _materials.FirstOrDefault(x => String.Equals(x.name, collectableType
                                                                 +MATERIAL_PREFIX, StringComparison.OrdinalIgnoreCase));
        }
    }
}
