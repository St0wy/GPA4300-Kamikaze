using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.LevelSelect;

namespace Kamikaze.UI
{
    public class UIShowTroopBehaviour : MonoBehaviour
    {
        [SerializeField] private LevelsManagerScriptableObject levelsManagerScriptableObject;
        [SerializeField] private int levelToReach;
        [SerializeField] private GameObject troopPanelUnlock;
        [SerializeField] private GameObject troopPanelLock;
        
        public bool IsUnlocked { get; set; }
        

        // Start is called before the first frame update
        void Start()
        {
            if (levelsManagerScriptableObject.CurrentLevelId + 1 == levelToReach)
            {
                IsUnlocked = true;
            }
        }


        public void ShowUnlockedPanel()
        {
            troopPanelUnlock.SetActive(true);
        }
        public void HideUnlockedPanel()
        {
            troopPanelUnlock.SetActive(false);
        }


        public void ShowLockedPanel()
        {
            troopPanelLock.SetActive(true);
        }
        public void HideLockedPanel()
        {
            troopPanelLock.SetActive(false);
        }

   

     




    }
}
