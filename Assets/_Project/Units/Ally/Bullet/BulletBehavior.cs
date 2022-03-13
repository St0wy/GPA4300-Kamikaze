using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class BulletBehavior : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private Material freezeColor;
        [SerializeField] private Material normalColor;
       
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Movement = Vector3.right;
            Movement.Normalize();

            Speed = 800f;
            //IsFrozen = false;
        }

        private void Update()
        {
            if(IsFrozen)
            {
                Speed = 300f;
                GetComponent<MeshRenderer>().material = freezeColor;
            }

            else
            {
                Speed = 800f;
                GetComponent<MeshRenderer>().material = normalColor;
            }
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            rb.velocity = Movement * Speed * Time.fixedDeltaTime;
        }

        public bool IsFrozen { get; set; }

        public float Speed { get; set; }

        public Vector3 Movement { get; private set; }
    }
}
