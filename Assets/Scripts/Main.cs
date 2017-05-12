using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	void Start ()
	{
		Obj.Prototype.Init();
		for (int i = 0; i < Grid.grids.Count; i++) { Grid.grids[i].Init(); }
	}
	
	void Update ()
	{
		Timer.Update();
		InputManager.Update();
	}
}
