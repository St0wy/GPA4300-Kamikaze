using System;
using Kamikaze.Units.Ally.Explosions;
using Kamikaze.Units.Ally.Freezer;
using UnityEngine;

namespace Kamikaze.Units.Ally.Kamikaze
{
    [RequireComponent(typeof(FreezeBehaviour))]
    [RequireComponent(typeof(ExplodeOnDeathBehaviour))]
    public class KamikazeFreezeBehaviour : MonoBehaviour
    {
        private FreezeBehaviour freezeBehaviour;
        private ExplodeOnDeathBehaviour explodeOnDeathBehaviour;

        private void Awake()
        {
            explodeOnDeathBehaviour = GetComponent<ExplodeOnDeathBehaviour>();
            freezeBehaviour = GetComponent<FreezeBehaviour>();
            freezeBehaviour.OnFreeze += OnFreeze;
            freezeBehaviour.OnUnFreeze += OnUnFreeze;
        }

        private void OnUnFreeze()
        {
            explodeOnDeathBehaviour.ExplosionEvent -= FreezeOnExplode;
        }

        private void OnFreeze()
        {
            explodeOnDeathBehaviour.ExplosionEvent += FreezeOnExplode;
        }

        private static void FreezeOnExplode(Collider col)
        {
            var colFreezeBehaviour = col.GetComponent<FreezeBehaviour>();

            if (colFreezeBehaviour != null)
            {
                colFreezeBehaviour.Freeze();
            }
        }
    }
}