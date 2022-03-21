using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider rayProvider;
        private ISelector selector;
        private ISelectionResponse selectionResponse;

        public Transform CurrentSelection { get; private set; }

        private void Awake()
        {
            rayProvider = GetComponent<IRayProvider>();
            selector = GetComponent<ISelector>();
            selectionResponse = GetComponent<ISelectionResponse>();
        }

        private void Update()
        {
            if (CurrentSelection != null) 
                selectionResponse.OnDeselect(CurrentSelection);
        
            selector.Check(rayProvider.CreateRay());
            CurrentSelection = selector.Selection;
        
            if (CurrentSelection != null) 
                selectionResponse.OnSelect(CurrentSelection);
        }
    }
}