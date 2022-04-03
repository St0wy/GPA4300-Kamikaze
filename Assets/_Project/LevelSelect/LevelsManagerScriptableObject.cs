using UnityEngine;

namespace Kamikaze.LevelSelect
{
	[CreateAssetMenu(order = 0, fileName = "levelsManager", menuName = "Levels/Levels Manager")]
	public class LevelsManagerScriptableObject : ScriptableObject
	{
		[SerializeField] private Level[] levels;
		[SerializeField] public Color lockedColor;
		[SerializeField] private Color finishedColor;
		[SerializeField] private Color playableColor;

		public int CurrentLevelId { get; set; }

		public Level[] Levels => levels;
		public Color LockedColor => lockedColor;
		public Color FinishedColor => finishedColor;
		public Color PlayableColor => playableColor;

		public void FinishCurrentLevel()
		{
			CurrentLevelId++;
			
			for (var i = 0; i < levels.Length; i++)
			{
				if (i < CurrentLevelId)
				{
					levels[i].LevelStatus = LevelStatus.Finished;
				} else if (i == CurrentLevelId)
				{
					levels[i].LevelStatus = LevelStatus.Playable;
				} else if (i > CurrentLevelId)
				{
					levels[i].LevelStatus = LevelStatus.Locked;
				}
			}
		}
	}
}