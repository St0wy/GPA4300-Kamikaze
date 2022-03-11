using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units
{
    public class ShieldTroopBehavior : MonoBehaviour
    {
        [SerializeField] private UnitBehaviour unitBehaviour;
        [SerializeField] private MoveOnLaneBehaviour moveOnLaneBehaviour;
        [SerializeField] private GameObject shieldGo;
        [SerializeField] private float stopPosition;
        

        // Start is called before the first frame update
        void Start()
        {
            unitBehaviour = GetComponent<UnitBehaviour>();
            moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
            
        }

        // Update is called once per frame
        void Update()
        {
            if(unitBehaviour.Position >= stopPosition)
            {
                moveOnLaneBehaviour.SetMoveDirection(MoveDirection.Nowhere);
                shieldGo.transform.localScale = new Vector3(0.20000000f, 0.9f, 0.9f);
            }
        }
    }
}
