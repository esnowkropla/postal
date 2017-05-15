using UnityEngine;
using System.Collections;

using TypeInfo;

public class Main : MonoBehaviour
{
	void Start ()
	{
		Type.Init();
		Globals.Init();
		SheetFuncs.LoadSheets();

		Obj.Prototype.Init();

		for (int i = 0; i < Grid.grids.Count; i++) { Grid.grids[i].Init(); }
	}
	
	void Update ()
	{
		Timer.Update();
		InputManager.Update();
	}
}
