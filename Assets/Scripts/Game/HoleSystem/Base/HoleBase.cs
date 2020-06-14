using Game.HoleSystem.Controllers;
using UnityEngine;
using Zenject;

namespace Game.HoleSystem.Base
{
    public class HoleBase : MonoBehaviour
    {
        private HoleMovementController _holeMovementController;
        private HolePhysicsController _holePhysicsController;
        
        [Inject]
        private void OnInstaller(HoleMovementController holeMovementController, HolePhysicsController holePhysicsController)
        {
            _holeMovementController = holeMovementController;
            _holePhysicsController = holePhysicsController;
        }
        
        
        public void Initialize()
        {
            _holeMovementController.Initialize(transform);
            _holePhysicsController.Initialize();
        }
        
    }
}
