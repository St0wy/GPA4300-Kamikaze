using MyBox;
using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
    public class RayCastBasedTagSelector : MonoBehaviour, ISelector
    {
        [Tag] [SerializeField] private string selectableTag;
        [SerializeField] private LayerMask layersToIgnore;
        [SerializeField] private float maxDistance = 1000f;

        public Transform Selection { get; private set; }

        public void Check(Ray ray)
        {
            Selection = null;

            if (!Physics.Raycast(ray, out RaycastHit hit, maxDistance, ~layersToIgnore)) return;

            Transform hitTransform = hit.transform;
            if (hitTransform.CompareTag(selectableTag))
            {
                Selection = hitTransform;
            }
        }
    }
}