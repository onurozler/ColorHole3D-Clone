using Game.LevelSystem.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] 
        private Image _levelFill;

        private LevelCollectableController _levelCollectableController;
        
        [Inject]
        private void OnInstaller(LevelCollectableController levelCollectableController)
        {
            
        }

        private void CurrentLevel(int level)
        {
            Debug.Log(level);
        }
    }
}
