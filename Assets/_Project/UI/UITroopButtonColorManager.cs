using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.LevelSelect;
using UnityEngine.UI;

namespace Kamikaze.UI
{
    public class UITroopButtonColorManager : MonoBehaviour
    {
        [SerializeField] private InventoryScriptableObject inventory;
        [SerializeField] private int unitID;
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }
        // Start is called before the first frame update
       
        // Update is called once per frame
        void Update()
        {
            if (inventory.UnitsAmount[unitID] <= 0)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
}
