using System;
using UnityEngine;
using Kamikaze.Audio;

namespace Kamikaze.Units.Ally.Explosions
{
	[CreateAssetMenu(fileName = "explosion", menuName = "Explosion", order = 0)]
	[Serializable]
	public class ExplosionScriptableObject : ScriptableObject
	{
		[SerializeField] private ExplosionType type = ExplosionType.Big;

		[Tooltip("Time of the explosion in seconds.")] [SerializeField]
		private float explosionTime = 2f;

		[Tooltip("The radius of the explosion.")] [SerializeField]
		private float explosionRadius = 1f;

		[Tooltip("The max damage that the explosion can do.")] [SerializeField]
		private int maxExplosionDamage = 20;

		[Tooltip("A margin at which the damage calculation will keep the max damages")] [SerializeField]
		private float maxDamageMargin = 2f;

		[Tooltip("Sound of explosion")] [SerializeField]
		private SoundEffectScriptableObject explosionSound;

		[Tooltip("The intensity of the screenshake that the explosion will produce")] [SerializeField]
		private float screenShakePower;

		[Tooltip("The duration of the sreenshake that the explosion will produce")] [SerializeField]
		private float screenShakeDuration;


		public ExplosionType Type => type;
		public float ExplosionTime => explosionTime;
		public float ExplosionRadius => explosionRadius;
		public float ScreenShakePower => screenShakePower;
		public float ScreenShakeDuration => screenShakeDuration;

		public SoundEffectScriptableObject ExplosionSound => explosionSound;

		/// <summary>
		///     The difference between the <see cref="ExplosionRadius" /> and the <see cref="MaxDamageMargin" />.
		/// </summary>
		public float RadiusDifference => explosionRadius - maxDamageMargin;

		public int MaxExplosionDamage => maxExplosionDamage;
		public float MaxDamageMargin => maxDamageMargin;
	}
}