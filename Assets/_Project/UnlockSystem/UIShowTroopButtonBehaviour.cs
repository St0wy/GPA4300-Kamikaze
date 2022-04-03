using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.LevelSelect;
using UnityEngine.UI;
using Kamikaze.Units.Ally;

namespace Kamikaze.UnlockSystem
{
    public class UIShowTroopButtonBehaviour : MonoBehaviour
    {
        [SerializeField] private LevelsManagerScriptableObject levelsManagerScriptableObject;
        [SerializeField] private AllyTroopScriptableObject troopData;
        [SerializeField] private int levelToReach;
        [SerializeField] private GameObject lockPrefab;
        [SerializeField] private GameObject troopNameGo;
        [SerializeField] private GameObject quantityGo;

        public int LevelToReach { get => levelToReach;}
       

        private void Start()
        {
            if (levelsManagerScriptableObject.CurrentLevelId + 1 >= levelToReach)
            {
                troopData.IsUnlocked = true;
            }
            ShowButton();
        }

        private void Update()
        {
            ShowButton();
        }


        public void ShowButton()
        {
            
            if (troopData.IsUnlocked)
            {
                ShowUnlockState();             
            }

            else if (!troopData.IsUnlocked)
            {
                ShowLockState();
            }
        }


        public void ShowLockState()
        {
            lockPrefab.SetActive(true);

            troopNameGo.SetActive(false);
            quantityGo.SetActive(false);
           
        }
        public void ShowUnlockState()
        {
            lockPrefab.SetActive(false);

            troopNameGo.SetActive(true);
            quantityGo.SetActive(true);
        }

    }
}
