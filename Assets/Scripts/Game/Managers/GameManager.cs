using Game.HoleSystem.Base;
using Game.LevelSystem.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        private LevelGenerator _levelGenerator;
        private HoleBase _holeBase;
        
        [Inject]
        private void OnInstaller(HoleBase holeBase, LevelGenerator levelGenerator)
        {
            _holeBase = holeBase;
            _levelGenerator = levelGenerator;
        }

        private void Start()
        {
            _holeBase.Initialize();
            _levelGenerator.GenerateNewLevel();
        }
    }
}
