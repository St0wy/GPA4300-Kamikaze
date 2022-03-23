using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
    public interface ISelector
    {
        void Check(Ray ray);
        Transform Selection { get; }
        Vector3 Point { get; }
    }
}