using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
	public static Ghost self;
	public Obj obj;
	void Start ()
	{
		self = this;
		Material mat = new Material(GetComponentInChildren<MeshRenderer>().material);
		mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.5f);
		GetComponentInChildren<MeshRenderer>().material = mat;
		//puppet.SetActive(false);
		//puppet.GetComponent<MeshCollider>().enabled = false;
	}
	
	void Update ()
	{
		obj.x = Mathf.RoundToInt(transform.position.x);
		obj.y = Mathf.RoundToInt(transform.position.y);
	}

	public static void Position(Vector3 pos) { self.transform.position = pos; self.transform.position += Vector3.back * 0.1f; }
}
