using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.LevelSelect;
using Kamikaze.Units.Ally;

namespace Kamikaze.UnlockSystem
{
    public class UIShowTroopPanelBehaviour : MonoBehaviour
    {
        [SerializeField] private LevelsManagerScriptableObject levelsManagerScriptableObject;
        [SerializeField] private int levelToReach;
        [SerializeField] private GameObject troopPanelUnlock;
        [SerializeField] private GameObject troopPanelLock;


        public bool CanUnlockPanel { get; set; } = false;

        public int LevelToReach { get => levelToReach; }
       


        public void ShowPanel()
        {
            if (levelsManagerScriptableObject.CurrentLevelId + 1 >= levelToReach)
            {
                CanUnlockPanel = true;
            }

            if (CanUnlockPanel)
            {            
                ShowUnlockedPanel();
                HideLockedPanel();
            }

            else if(!CanUnlockPanel)
            {
                ShowLockedPanel();
                HideUnlockedPanel();
            }
        }

        void ShowUnlockedPanel()
        {
            troopPanelUnlock.SetActive(true);
        }
        void HideUnlockedPanel()
        {
            troopPanelUnlock.SetActive(false);
        }


        void ShowLockedPanel()
        {
            troopPanelLock.SetActive(true);
        }

        void HideLockedPanel()
        {
            troopPanelLock.SetActive(false);
        }

   

     




    }
}
