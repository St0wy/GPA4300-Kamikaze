using Kamikaze.Lanes;
using Kamikaze.Lanes.Selection;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Ally.Shield
{
    public class ShieldGhostCursorBehaviour : MonoBehaviour
    {
        [SerializeField] private SelectionManager selectionManager;
        [SerializeField] private UnitSelector unitSelector;
        [SerializeField] private int unitID;
        [SerializeField] private MeshRenderer[] renderers;

        private LaneUnitBehaviour laneUnitBehaviour;

        private void Awake()
        {
            laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
            HideGhost();
        }

        private void Update()
        {
            Transform currentSelection = selectionManager.CurrentSelection;

            if (currentSelection == null)
            {
                HideGhost();
            }
            else
            {
                if (unitSelector.SelectedUnitId != unitID) return;

                ShowGhost();

                //Get lane position of ghost cursor
                var lane = currentSelection.GetComponent<Lane>();

                if (lane == null) return;

                Vector3 mousePos = selectionManager.CurrentPoint;
                float ghostPositionOnLane = lane.GetLanePositionFromWorld(mousePos);

                // Get lane id of ghost
                int currentSelectionLaneId = lane.Id;

                // Place the ghost on lane
                laneUnitBehaviour.Position = ghostPositionOnLane;
                laneUnitBehaviour.LaneId = currentSelectionLaneId;
            }
        }

        public void HideGhost()
        {
            SetEnableOnRenderers(false);
        }

        public void ShowGhost()
        {
            SetEnableOnRenderers(true);
        }

        private void SetEnableOnRenderers(bool status)
        {
            renderers.ForEach(render => render.enabled = status);
        }
    }
}