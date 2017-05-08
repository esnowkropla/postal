using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{
	public GameObject Tile;
	public GameObject Obj;
	public Material[] materials;

	public static Globals go;

	public static int ids = 0;
	public static float paused = 0;
	public static Logging.Level debug = Logging.Level.LOG | Logging.Level.WARN | Logging.Level.ERROR;

	public void Awake()
	{
		go = this;
	}
}
