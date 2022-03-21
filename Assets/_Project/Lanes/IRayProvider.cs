using UnityEngine;

namespace Kamikaze.Lanes
{
    public interface IRayProvider
    {
        Ray CreateRay();
    }
}