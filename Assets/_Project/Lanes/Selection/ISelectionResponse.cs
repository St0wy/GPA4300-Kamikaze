using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
    internal interface ISelectionResponse
    {
        void OnSelect(Transform selection);
        void OnDeselect(Transform selection);
    }
}