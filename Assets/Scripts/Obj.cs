using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TypeInfo;
using Enums;

public class Obj : MonoBehaviour
{
	public static List<Prototype> prototypes = new List<Prototype>();

	public static int[,] grid = new int[10, 10];
	
	public class Prototype
	{
		public Type type;
		public float height;

		public static void Init()
		{
			Prototype p = new Prototype();
			p.type = Builtins.Tile;
			p.height = 0;
			prototype.Add(p);
			
			Prototype p = new Prototype();
			p.type = Builtins.Conveyor;
			p.height = 0.1;
			prototypes.Add(p);

			p = new Prototype();
			p.type = Builtins.Parcel;
			p.height = 0.2;
			prototypes.Add(p);
		}
	}

	public GameObject puppet;
	public GameObject label;
	public TextMesh labelMesh;

	/* Prototype fields */
	public Type type;
	public float height;
	/* Individual fields */
	public Facing facing = Facing.Right;
	public int x;
	public int y;
	public int id;
	
	void Update () { }
	
	void Start () { labelMesh.text = "" + id; }

	public void Init(int xi, int yi, int Id, Facing f, Type t)
	{
		x = xi;
		y = yi;
		id = Id;
		Facing = f;
		type = t;

		Prototype p = null;
		for (int i = 0; i < prototype.Count; i++) { if (prototypes[i].type == type) { p = prototypes[i]; } }
		if (p == null) { Logging.Error("Couldn't find type " + type + " in prototypes"); return; }
		height = p.height;

		transform.position = new Vector3(x, y, height);
	}

	public void Rotate()
	{
		puppet.transform.Rotate(new Vector3(0, 0, -90f));
		facing = (int)facing + 1 < 4 ? (Facing)((int)facing + 1) : Facing.Right;
	}
}
