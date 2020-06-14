using System;
using Game.HoleSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        private HoleBase _holeBase;
        
        [Inject]
        private void OnInstaller(HoleBase holeBase)
        {
            _holeBase = holeBase;
        }

        private void Start()
        {
            _holeBase.Initialize();
        }
    }
}
