using UnityEngine;

namespace Kamikaze.Lanes
{
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider rayProvider;
        private ISelector selector;
        private ISelectionResponse selectionResponse;
    
        private Transform currentSelection;

        private void Awake()
        {
            rayProvider = GetComponent<IRayProvider>();
            selector = GetComponent<ISelector>();
            selectionResponse = GetComponent<ISelectionResponse>();
        }

        private void Update()
        {
            if (currentSelection != null) 
                selectionResponse.OnDeselect(currentSelection);
        
            selector.Check(rayProvider.CreateRay());
            currentSelection = selector.Selection;
        
            if (currentSelection != null) 
                selectionResponse.OnSelect(currentSelection);
        }
    }
}