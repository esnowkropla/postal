using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Structs;
using Enums;

public class Ghost : MonoBehaviour
{
	public static Ghost self;
	public Obj obj;

	List<InputResponse> responses = new List<InputResponse>();

	void Start ()
	{
		self = this;
		Material mat = new Material(GetComponentInChildren<MeshRenderer>().material);
		mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.5f);
		GetComponentInChildren<MeshRenderer>().material = mat;
		obj.puppet.SetActive(false);

		responses.Add(new InputResponse(INPUT_EVENT.ROTATE_CLOCKWISE, obj.RotateClockwise));
		responses.Add(new InputResponse(INPUT_EVENT.ROTATE_COUNTER_CLOCKWISE, obj.RotateCounterClockwise));
	}
	
	void Update ()
	{
		obj.x = Mathf.RoundToInt(transform.position.x);
		obj.y = Mathf.RoundToInt(transform.position.y);
		InputManager.FilterInput(responses);
	}

	public static void Position(Vector3 pos) { self.transform.position = pos; self.transform.position += Vector3.back * 0.01f; }
}
