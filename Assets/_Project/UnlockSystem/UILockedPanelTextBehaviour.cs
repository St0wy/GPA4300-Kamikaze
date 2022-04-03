using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Kamikaze.UnlockSystem
{
    public class UILockedPanelTextBehaviour : MonoBehaviour
    {

        [SerializeField] private UIShowTroopPanelBehaviour uIShowTroopBehaviour;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        // Start is called before the first frame update
        void Start()
        {
            DisplayMenuLockPanelText();        
        }

        void DisplayMenuLockPanelText()
        {
            textMeshProUGUI.text =
                "Finish\x0A"
                + "level " + uIShowTroopBehaviour.LevelToReach.ToString() + "\x0A"
                + "to unlock\x0A"
                + "troop!";
        }
    }
}
