using UnityEngine;

using TypeInfo;

public class Grid : MonoBehaviour
{
	public void Start()
	{
		for (int x = 0; x < 10; x++)
		{
			for (int y = 0; y < 10; y++)
			{
				GameObject go = Instantiate(Globals.go.Obj, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
				go.GetComponent<Obj>().Init(x, y, Builtins.Tile);
			}
		}
	}
}
