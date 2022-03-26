using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kamikaze.PlayerLife
{
    public class UiLifeManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lifeTextUi;
        [SerializeField] private LifeManager lifeManager;

        // Update is called once per frame
        private void Update()
        {
            lifeTextUi.text = lifeManager.PlayerLife.ToString();
        }
      
    }
}
