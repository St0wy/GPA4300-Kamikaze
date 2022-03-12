using UnityEngine;

namespace Kamikaze
{
    /// <summary>
    /// Manages the lanes in the scene.
    /// </summary>
    public class LanesManager : MonoBehaviour
    {
        [SerializeField] private Lane[] lanes;

        /// <summary>
        /// Gets the lanes array.
        /// </summary>
        public Lane[] Lanes => lanes;
    }
}