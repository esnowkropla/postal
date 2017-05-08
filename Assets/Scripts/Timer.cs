using UnityEngine;

public static class Timer
{
	public static float time;
	public static float uiTime;
	public static float deltaTime;
	public static float uiDeltaTime;

	static float timeUpdater = 0;

	public static void Update()
	{
		if (Time.timeSinceLevelLoad > timeUpdater)
		{
			deltaTime = (1 - Globals.paused ) * (Time.timeSinceLevelLoad - timeUpdater);
			time += (1 - Globals.paused) * deltaTime;

			uiDeltaTime = (Time.timeSinceLevelLoad - timeUpdater);
			uiTime += uiDeltaTime;

			timeUpdater = Time.timeSinceLevelLoad;
		}
	}
}
