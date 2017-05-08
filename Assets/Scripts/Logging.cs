using UnityEngine;

public static class Logging
{
	public enum Level
	{
		NONE  = 1 << 0,
		LOG   = 1 << 1,
		WARN  = 1 << 2,
		ERROR = 1 << 3
	}

	public static void Log(string text)
	{
		if ((Globals.debug & Level.LOG) == Level.LOG) { Debug.Log(text); }
	}

	public static void Warn(string text)
	{
		if ((Globals.debug & Level.WARN) == Level.WARN) { Debug.Log(text); }
	}

	public static void Error(string text)
	{
		if ((Globals.debug & Level.ERROR) == Level.ERROR) { Debug.LogError(text); }
	}
}
