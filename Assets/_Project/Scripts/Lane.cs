using System;
using UnityEngine;

namespace Kamikaze
{
    // [Serializable]
    public class Lane : MonoBehaviour
    {
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;

        public Vector3 StartPos => startPos.position;
        public Vector3 EndPos => endPos.position;

        public Lane(Transform startPos, Transform endPos)
        {
            this.startPos = startPos;
            this.endPos = endPos;
        }
    }
}