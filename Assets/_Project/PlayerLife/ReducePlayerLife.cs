using UnityEngine;
using Kamikaze.Units;

namespace Kamikaze.PlayerLife
{
    public class ReducePlayerLife : MonoBehaviour
    {
        private LaneUnitBehaviour laneUnitBehaviour;

        public LifeManager LifeManager { get; set; }
        
        private void Awake()
        {
            laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
        }

        private void Update()
        {
            if (!(laneUnitBehaviour.Position <= 0)) return;
            
            LifeManager.PlayerLife--;
            if(LifeManager.PlayerLife <= 0)
            {
                LifeManager.PlayerLife = 0;
            }
        }
    }
}
