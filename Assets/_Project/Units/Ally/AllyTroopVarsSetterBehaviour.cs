using UnityEngine;

namespace Kamikaze.Units.Ally
{
    /// <summary>
    /// This behaviour is used to set the variables presents in the scriptable object to the mono behaviours.
    /// </summary>
    [RequireComponent(typeof(HealthBehaviour), typeof(MoveOnLaneBehaviour))]
    public class AllyTroopVarsSetterBehaviour : MonoBehaviour
    {
        [SerializeField] private AllyTroopScriptableObject allyTroopScriptableObject;

        private HealthBehaviour healthBehaviour;
        private MoveOnLaneBehaviour moveOnLaneBehaviour;

        private void Awake()
        {
            healthBehaviour = GetComponent<HealthBehaviour>();
            moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
            healthBehaviour.MaxHealthPoints = allyTroopScriptableObject.HealthPoints;
            moveOnLaneBehaviour.MoveSpeed = allyTroopScriptableObject.MoveSpeed;
        }
    }
}