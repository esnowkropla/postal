using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoggingText : MonoBehaviour
{
	public Text text;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		text.text = Mathf.RoundToInt(Timer.deltaTime * 1000) + "ms";
	}
}
