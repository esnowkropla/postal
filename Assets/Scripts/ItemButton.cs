using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using TypeInfo;

using Enums;

public class ItemButton : MonoBehaviour
{
	public Type type;

	void Start () { }
	void Update () { }

	public void OnClick()
	{
		Ghost.self.Activate(Builtins.Conveyor, Facing.Right);
	}
}
