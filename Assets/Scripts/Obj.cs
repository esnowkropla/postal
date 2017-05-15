using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TypeInfo;
using Structs;
using Enums;

public class Obj : MonoBehaviour
{
	public static List<Prototype> prototypes = new List<Prototype>();
	
	public struct Prototype
	{
		public Type type;
		public float height;
		public GridLayer layer;
		public List<Anim.Animation> animations;

		public static void Init()
		{
			prototypes.Add(Prototypes.Tile());
			prototypes.Add(Prototypes.Conveyor());
			prototypes.Add(Prototypes.Parcel());
		}
	}

	public GameObject puppet;
	public GameObject label;
	public TextMesh labelMesh;

	/* Prototype fields */
	public Type type;
	public float height;
	public GridLayer layer;
	public Anim animator;
	/* Individual fields */
	public Facing facing = Facing.Right;
	public Grid grid;
	public int x;
	public int y;
	public int id;
	
	void Update () { }
	
	void Start () { labelMesh.text = "" + id; }

	public static void Create(int x, int y, int id, Facing facing, Type type, Grid g)
	{
		GameObject go = Instantiate(Globals.go.Obj, g.transform.position, g.transform.rotation) as GameObject;
		go.transform.parent = g.transform;
		go.GetComponent<Obj>().Init(x, y, id, facing, type, g);
	}

	public void Init(int xi, int yi, int Id, Facing f, Type t, Grid g)
	{
		x = xi;
		y = yi;
		id = Id;
		facing = f;
		type = t;
		grid = g;

		Prototype p = default(Prototype);
		for (int i = 0; i < prototypes.Count; i++) { if (prototypes[i].type == type) { p = prototypes[i]; } }
		if (p.type == Builtins.Uninitialized) { Logging.Error("Couldn't find type " + type + " in prototypes"); return; }
		height = -p.height;
		layer = p.layer;

		animator.animations = p.animations;

		animator.StartAnimation(animator.animations[0]);
		MatchFacing();

		transform.localPosition = new Vector3(x, y, height);
		grid.cells[x, y, layer] = id;
	}

	void MatchFacing()
	{
		puppet.transform.localRotation = Quaternion.identity;
		switch (facing)
		{
			case Facing.Left: puppet.transform.Rotate(Vector3.forward * 180f); break;
			case Facing.Down: puppet.transform.Rotate(Vector3.forward * -90f); break;
			case Facing.Up: puppet.transform.Rotate(Vector3.forward * 90f); break;
			case Facing.Right: break;
		}
	}

	public void RotateClockwise()
	{
		puppet.transform.Rotate(Vector3.forward * -90f);
		facing = (Facing)(((int)facing + 1) % 4);
	}

	public void RotateCounterClockwise()
	{
		puppet.transform.Rotate(Vector3.forward * 90f);
		facing = (int)facing - 1 < 0 ? Facing.Up : (Facing) ((int)facing - 1);
	}
}
