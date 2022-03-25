using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.Units;

namespace Kamikaze.PlayerLife
{
    public class ReducePlayerLife : MonoBehaviour
    {
        private LaneUnitBehaviour laneUnitBehaviour;
       

        public LifeManager LifeManager { get; set; }
        // Start is called before the first frame update
        void Start()
        {
            laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
        }

        // Update is called once per frame
        void Update()
        {
            if(laneUnitBehaviour.Position <= 0)
            {
                LifeManager.PlayerLife--;
                if(LifeManager.PlayerLife <= 0)
                {
                    LifeManager.PlayerLife = 0;
                }
            }
        }
    }
}
