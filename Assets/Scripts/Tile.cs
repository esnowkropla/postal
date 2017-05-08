using UnityEngine;
using System.Collections;

using TypeInfo;
using Enums;

public class Tile : MonoBehaviour
{
	public enum State
	{
		Normal,
		Highlight
	}

	public GameObject puppet;
	public MeshFilter meshFilter;
	public MeshRenderer meshRenderer;

	public State state = State.Normal;
	public Type type = Builtins.Tile;

	void Start () { }
	
	void Update () { }

	public void Toggle()
	{
		if (state == State.Normal) { meshRenderer.material = Globals.go.materials[1]; state = State.Highlight; }
		else if (state == State.Highlight) { meshRenderer.material = Globals.go.materials[0]; state = State.Normal; }
	}

	public void CreateOn(Type type)
	{
		for (int i = 0; i < Obj.prototypes.Count; i++)
		{
			Obj.Prototype p = Obj.prototypes[i];
			if (p.type != type) { continue; }

			GameObject go = Instantiate(Globals.go.Obj, transform.position, transform.rotation) as GameObject;
			go.transform.position += Vector3.back * 0.1f;
			Obj obj = go.GetComponent<Obj>();
			obj.type = Builtins.Conveyor;
			obj.id = Globals.ids++;
			Debug.Log("Making a conveyor");
			break;
		}
	}
}
