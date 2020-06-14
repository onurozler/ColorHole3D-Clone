using System.Collections.Generic;
using Game.LevelSystem.Model;
using Zenject;

namespace Game.LevelSystem.Managers
{
    public class LevelManager
    {
        private List<LevelData> _levelDatas;
        
        [Inject]
        private void OnInstaller(List<LevelData> levelDatas)
        {
            _levelDatas = levelDatas;
        }
        
        public void  LoadLevel(int index)
        {
                
        }
    }
}
