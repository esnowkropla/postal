using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using TypeInfo;

public class ItemButton : MonoBehaviour
{
	public Type type;

	void Start () { }
	void Update () { }

	public void OnClick()
	{
		Ghost.self.obj.puppet.SetActive(true);
		Ghost.self.obj.type = Builtins.Conveyor;
	}
}
