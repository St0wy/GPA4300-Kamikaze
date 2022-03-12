using UnityEngine;

namespace Kamikaze
{
    /// <summary>
    /// Class that represents a lane.
    /// </summary>
    public class Lane : MonoBehaviour
    {
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;

        /// <summary>
        /// Gets the start position of the lane.
        /// </summary>
        public Vector3 StartPos => startPos.position;
        
        /// <summary>
        /// Gets the end position of the lane.
        /// </summary>
        public Vector3 EndPos => endPos.position;
    }
}