using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoggingText : MonoBehaviour
{
	public static LoggingText self;
	public Text text;

	void Start ()
	{
		self = this;
	}
	
	void Update ()
	{
		//text.text = Mathf.RoundToInt(Timer.deltaTime * 1000) + "ms";
	}
}
