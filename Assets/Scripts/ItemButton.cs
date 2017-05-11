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
		Ghost.self.obj.puppet.SetActive(true);
		Ghost.self.obj.type = Builtins.Conveyor;
		Ghost.self.obj.facing = Facing.Right;
		Ghost.self.obj.puppet.transform.localRotation = Quaternion.identity;
	}
}
