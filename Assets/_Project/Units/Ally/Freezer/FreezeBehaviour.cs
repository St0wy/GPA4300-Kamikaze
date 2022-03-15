﻿using System.Collections;
using UnityEngine;

namespace Kamikaze.Units.Ally.Freezer
{
    public delegate void FreezeEvent();
    
    public class FreezeBehaviour : MonoBehaviour
    {
        [SerializeField] private float freezeTime = 0.1f;

        public bool IsFrozen { get; private set; }
        
        public FreezeEvent OnFreeze { get; set; }
        public FreezeEvent OnUnFreeze { get; set; }

        public virtual void Freeze()
        {
            IsFrozen = true;
            OnFreeze?.Invoke();
            StartCoroutine(UnFreezeCoroutine());
        }

        private IEnumerator UnFreezeCoroutine()
        {
            yield return new WaitForSeconds(freezeTime);
            OnUnFreeze?.Invoke();
            IsFrozen = false;
        }
    }
}