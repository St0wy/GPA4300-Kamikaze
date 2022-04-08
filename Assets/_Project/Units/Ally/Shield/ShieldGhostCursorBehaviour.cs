using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.Lanes.Selection;
using Kamikaze.Lanes;


namespace Kamikaze.Units.Ally.Shield
{
    public class ShieldGhostCursorBehaviour : MonoBehaviour
    {
        [SerializeField] private SelectionManager selectionManager;
        [SerializeField] private UnitSelector unitSelector;
        [SerializeField] private int unitID;
        [SerializeField] private MeshRenderer[] renderers;
       

        // Start is called before the first frame update
        void Start()
        {
            MoveOnLaneBehaviour moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
            moveOnLaneBehaviour.MoveSpeed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            Transform currentSelection = selectionManager.CurrentSelection;
            if (currentSelection == null) 
            {
                Hide();           
            }
            else
            {
                if (unitSelector.SelectedUnitId == unitID)
                {
                    Show();

                    //Get lane position of ghost cursor
                    var lane = currentSelection.GetComponent<Lane>();
                    Vector3 mousePos = selectionManager.CurrentPoint;
                    float ghostPositionOnLane = lane.GetLanePositionFromWorld(mousePos);

                    //Get lane id of ghost
                    var laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
                    int currentSelectionLaneId = lane.Id;
                    
                    //Apply      
                    laneUnitBehaviour.Position = ghostPositionOnLane;
                    laneUnitBehaviour.LaneId = currentSelectionLaneId;
                }
            }       
        }

        public void Hide()
        {
            foreach (var render in renderers)
            {
                render.enabled = false;
            }
        }

        public void Show()
        {
            foreach (var render in renderers)
            {
                render.enabled = true;
            }
        }
    }
}
