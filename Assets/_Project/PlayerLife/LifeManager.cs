using UnityEngine;

namespace Kamikaze.PlayerLife
{
    public class LifeManager : MonoBehaviour
    {
        [field: SerializeField]
        public int PlayerLife { get; set; } = 100;
       
    }
}
