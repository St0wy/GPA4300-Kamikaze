using UnityEngine;

namespace Kamikaze.Units.Ally.Shield
{
    public class ShieldTroopBehavior : MonoBehaviour
    {
        [SerializeField] private LaneUnitBehaviour unitBehaviour;
        [SerializeField] private MoveOnLaneBehaviour moveOnLaneBehaviour;
        [SerializeField] private GameObject shieldGo;
        [SerializeField] private float stopPosition;

        private void Start()
        {
            unitBehaviour = GetComponent<LaneUnitBehaviour>();
            moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
        }

        private void Update()
        {
            if (!(unitBehaviour.Position >= stopPosition)) return;
            
            moveOnLaneBehaviour.MoveSpeed = 0f;
            shieldGo.transform.localScale = new Vector3(0.20000000f, 0.9f, 0.9f);
        }
    }
}