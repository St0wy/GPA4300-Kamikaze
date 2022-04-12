using System;
using System.IO;
using StowyTools.Logger;
using UnityEngine;

namespace Kamikaze
{
	public class Screenshot : MonoBehaviour
	{
		[Tooltip("The time it takes in seconds to take a screenshot.")] [SerializeField]
		private float screenshotTime;

		private float timer;
		private string screenshotPath;

		private void Awake()
		{
			DontDestroyOnLoad(this);
			screenshotPath = Path.Combine(Application.dataPath, @"..\screenshots\");
		}

		private void Start()
		{
			if (!Directory.Exists(screenshotPath))
			{
				Directory.CreateDirectory(screenshotPath);
			}
		}

		private void Update()
		{
			if (!Debug.isDebugBuild) return;

			timer += Time.deltaTime;
			if (!(timer >= screenshotTime)) return;

			timer -= screenshotTime;
			TakeScreenshot();
		}

		public void TakeScreenshot()
		{
			DateTime now = DateTime.Now;
			string path = Path.Combine(screenshotPath, $"./kamikaze_{now:yyyy-MM-dd_hh-mm-ss}.png");
			ScreenCapture.CaptureScreenshot(path);
		}
	}
}