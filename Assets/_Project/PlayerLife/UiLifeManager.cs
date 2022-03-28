using UnityEngine;
using TMPro;

namespace Kamikaze.PlayerLife
{
    public class UiLifeManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI lifeTextUi;
        [SerializeField] private LifeManager lifeManager;

        private void Update()
        {
            lifeTextUi.text = lifeManager.PlayerLife.ToString();
        }
      
    }
}
