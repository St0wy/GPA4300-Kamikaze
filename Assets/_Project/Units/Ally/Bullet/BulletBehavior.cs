using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
    public class BulletBehavior : MonoBehaviour
    {
        [SerializeField] private Material freezeColor;
        [SerializeField] private Material normalColor;
        [SerializeField] private float frozenSpeed = 300f;
        [SerializeField] private float normalSpeed = 800f;
        
        private Rigidbody rb;

        public bool IsFrozen { get; set; }

        public float Speed { get; set; }

        public Vector3 Movement { get; set; }

        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            
            Movement.Normalize();
            
            Speed = normalSpeed;
        }

        private void Update()
        {
            if (IsFrozen)
            {
                Speed = frozenSpeed;
                GetComponent<MeshRenderer>().material = freezeColor;
            }
            else
            {
                Speed = normalSpeed;
                GetComponent<MeshRenderer>().material = normalColor;
            }
        }

        private void FixedUpdate()
        {
            rb.velocity = Movement * Speed * Time.fixedDeltaTime;
        }

        
    }
}