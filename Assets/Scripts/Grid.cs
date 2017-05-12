using UnityEngine;

using System.Collections.Generic;

using TypeInfo;
using Structs;
using Enums;

public class Grid : MonoBehaviour
{
	public static List<Grid> grids = new List<Grid>();

	public int id;
	public int[,,] cells = new int[10, 10,3];

	public void Awake() { id = grids.Count; grids.Add(this); }

	public void Init()
	{
		for (int z = 0; z < GridLayer.Top; z++)
		{
			for (int y = 0; y < 10; y++)
			{
				for (int x = 0; x < 10; x++)
				{
					cells[x, y, z] = -1;
				}
			}
		}

		for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 10; x++)
			{
				Obj.Create(x, y, Globals.ids++, Facing.Right, Builtins.Tile, this);
			}
		}
	}

	public Vector3 ToWorld(int x, int y)
	{
		return Vector3.zero;
	}

	public Pair<int> ToGrid(Vector3 pos)
	{
		return default(Pair<int>);
	}
}
