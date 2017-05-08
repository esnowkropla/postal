using UnityEngine;
using UnityEngine.EventSystems;
using System;

using TypeInfo;
using Structs;
using Enums;

public static class InputManager
{
	public static RingBuffer<InputEvent> eventBuffer = new RingBuffer<InputEvent>();
	static Ray mouseRay;
	static RaycastHit[] hits;

	static int CompareDistFromCamera(RaycastHit hit1, RaycastHit hit2)
	{
		return Mathf.RoundToInt(hit1.distance - hit2.distance);
	}
	
	public static void Update()
	{
		if (Input.GetKeyDown(KeyCode.A)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_LEFT_KDOWN, null)); }
		if (Input.GetKeyUp(KeyCode.A)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_LEFT_KUP, null)); }
		if (Input.GetKeyDown(KeyCode.D)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_RIGHT_KDOWN, null)); }
		if (Input.GetKeyUp(KeyCode.D)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_RIGHT_KUP, null)); }

		if (Input.GetKeyDown(KeyCode.W)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_FORWARD_KDOWN, null)); }
		if (Input.GetKeyUp(KeyCode.W)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_FORWARD_KUP, null)); }
		if (Input.GetKeyDown(KeyCode.S)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_BACK_KDOWN, null)); }
		if (Input.GetKeyUp(KeyCode.S)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_BACK_KUP, null)); }

		if (Input.GetKeyDown(KeyCode.Minus)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_ZOOM_OUT, null)); }
		if (Input.GetKeyDown(KeyCode.Equals)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.CAMERA_ZOOM_IN, null)); }

		if (Input.GetKeyUp(KeyCode.Escape)) { Application.Quit(); }

		if (Input.GetMouseButtonDown(0)) { HandleMouseDown(); }
		if (Input.GetMouseButtonUp(0)) { HandleMouseUp(); }
	}

	static void HandleMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject(-1)) { return; } /* We're over the UI so don't raycat */

		LayerMask mask = (1 << (int)UNITY_LAYERS.Obj);
		mouseRay = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		hits = Physics.RaycastAll(mouseRay, 3000, mask);
		Array.Sort(hits, CompareDistFromCamera);

		for (int i = 0; i < hits.Length; i++)
		{
			mouseUp = true;
			Obj obj = hits[i].transform.gameObject.GetComponent<Obj>();
			if (obj == null) { continue; }

			if (obj.type == Builtins.Parcel) { break; }
			else if (obj.type == Builtins.Conveyor) { Obj.Create(obj.x, obj.y, Globals.ids++, Facing.Right, Builtins.Parcel); break; }
			else if (obj.type == Builtins.Tile) { Obj.Create(obj.x, obj.y, Globals.ids++, Facing.Right, Builtins.Conveyor); break; }
		}
		if (mouseUp) { Sounds.PlayUI(Sounds.FX.ButtonDown); }
	}
	static bool mouseUp = false;

	static void HandleMouseUp()
	{
		if (mouseUp) { Sounds.PlayUI(Sounds.FX.ButtonUp); mouseUp = false;}
	}
}
