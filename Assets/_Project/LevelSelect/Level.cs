using System;
using MyBox;
using UnityEngine;

namespace Kamikaze.LevelSelect
{
	[Serializable]
	public class Level
	{
		[field: SerializeField] public SceneReference LevelScene { get; set; }
		[field: SerializeField] public LevelStatus LevelStatus { get; set; } = LevelStatus.Locked;
	}
}