using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamikaze.Lanes
{
    public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField] private Camera mainCamera;

        public Ray CreateRay()
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            return mainCamera.ScreenPointToRay(mousePos);
        }
    }
}