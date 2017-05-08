using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	void Start ()
	{
		Obj.Prototype.Init();
	}
	
	void Update ()
	{
		Timer.Update();
		InputManager.Update();
	}
}
