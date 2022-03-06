using MyBox;
using UnityEngine;

namespace Kamikaze
{
    public class UnitBehaviour : MonoBehaviour
    {
        private const float MinValuePosition = 0;
        private const float MaxValuePosition = 1;

        [SerializeField] private LanesManager lanesManager;

        [DefinedValues(0, 1, 2, 3, 4)]
        [SerializeField] private int laneId;

        [Tooltip("Position of the Unit on the lane from 0 to 1 where 0 = on the left and 1 = on the right.")] 
        [Range(0, 1)]
        [SerializeField]
        private float position = 0;

        public float Position
        {
            get => position;
            set
            {
                position = value;
                if (position > MaxValuePosition)
                {
                    position = MaxValuePosition;
                }
                else if (position < MinValuePosition)
                {
                    position = MinValuePosition;
                }
            }
        }

        private void Update()
        {
            Lane lane = lanesManager.Lanes[laneId];
            transform.position = Vector3.Lerp(lane.StartPos, lane.EndPos, position);
        }
    }
}