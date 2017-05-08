using UnityEngine;

using TypeInfo;
using Structs;
using Enums;

public class Grid : MonoBehaviour
{
	public static int[,,] grid = new int[10, 10,3];

	public void Start()
	{
		for (int z = 0; z < GridLayer.Top; z++)
		{
			for (int y = 0; y < 10; y++)
			{
				for (int x = 0; x < 10; x++)
				{
					grid[x, y, z] = -1;
				}
			}
		}

		for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 10; x++)
			{
				Obj.Create(x, y, Globals.ids++, Facing.Right, Builtins.Tile);
			}
		}
	}
}
