using System;
using UnityEngine;

namespace Kamikaze
{
    public class LanesManager : MonoBehaviour
    {
        [SerializeField] private Lane[] lanes;

        public Lane[] Lanes => lanes;
    }
}