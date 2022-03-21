using UnityEngine;

namespace Kamikaze.Lanes
{
    public interface ISelector
    {
        void Check(Ray ray);
        Transform Selection { get; }
    }
}