using Config;
using Game.CollectableObjectSystem.Base;
using Game.CollectableObjectSystem.Managers;
using Game.HoleSystem.Base;
using Game.HoleSystem.Controllers;
using Game.LevelSystem.Controllers;
using Game.LevelSystem.Managers;
using Game.LevelSystem.Model;
using Game.Managers;
using Game.View;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        private const string LEVEL_DATAS_PATH = "LevelDatas";
        private const string MATERIAL_PATH = "Materials";
        private const string COLLECTABLE_PREFAB_PATH = "Prefabs/CollectableBase";
        
        [SerializeField]
        private HoleBase _holeBase;
        
        [SerializeField] 
        private Transform _poolContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.BindInstance(_holeBase);
            Container.Bind<HoleMovementController>().AsSingle().NonLazy();
            Container.Bind<HolePhysicsController>().FromNewComponentOn(_holeBase.gameObject).AsSingle().NonLazy();

            Container.Bind<AssetManager>().AsSingle().NonLazy();
            Container.Bind<Material>().FromResources(MATERIAL_PATH).AsSingle();
            
            Container.BindMemoryPool<CollectableBase, CollectablePool>().WithInitialSize(GameConfig.POOL_INITIAL_COUNT)
               .FromComponentInNewPrefabResource(COLLECTABLE_PREFAB_PATH).UnderTransform(_poolContainer);

            Container.Bind<LevelData>().FromResources(LEVEL_DATAS_PATH).AsSingle();
            Container.Bind<LevelGenerator>().AsSingle().NonLazy();
            Container.Bind<LevelManager>().AsSingle().NonLazy();
            Container.Bind<LevelCollectableController>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}