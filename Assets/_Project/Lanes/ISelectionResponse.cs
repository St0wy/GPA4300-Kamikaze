using UnityEngine;

namespace Kamikaze.Lanes
{
    internal interface ISelectionResponse
    {
        void OnSelect(Transform selection);
        void OnDeselect(Transform selection);
    }
}