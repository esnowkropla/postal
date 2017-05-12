using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

using TypeInfo;
using Structs;
using Enums;

public static class InputManager
{
	public static RingBuffer<InputEvent> eventBuffer = new RingBuffer<InputEvent>();
	static Ray mouseRay;
	static RaycastHit[] hits = new RaycastHit[0];
	public static Vector3 mouseInWorld;

	static int CompareDistFromCamera(RaycastHit hit1, RaycastHit hit2)
	{
		return Mathf.RoundToInt(hit1.distance - hit2.distance);
	}

	static RingBuffer<InputEvent> buff = new RingBuffer<InputEvent>();
	public static void FilterInput(List<InputResponse> responses)
	{
		bool called;
		while (eventBuffer.Count > 0)
		{
			InputEvent e = eventBuffer.PopFront();
			called = false;
			for (int i = 0; i < responses.Count; i++)
			{
				if (e.type == responses[i].inputEvent.type) { responses[i].action(); called = true; }
			}
			if (!called) { buff.Add(e); }
		}

		while (buff.Count > 0) { InputEvent e = buff.PopFront(); eventBuffer.Add(e); }
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

		if (Input.GetKeyDown(KeyCode.Q)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.ROTATE_CLOCKWISE, null)); }
		if (Input.GetKeyDown(KeyCode.E)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.ROTATE_COUNTER_CLOCKWISE, null)); }

		if (Input.GetKeyDown(KeyCode.Alpha1)) { eventBuffer.Add(new InputEvent(INPUT_EVENT.TOGGLE_MENU_0, null)); }

		if (Input.GetKeyUp(KeyCode.Escape)) { Application.Quit(); }

		HandleMouse();
	}

	static void HandleMouse()
	{
		if (EventSystem.current.IsPointerOverGameObject(-1)) { return; } /* We're over the UI so don't raycat */

		LayerMask mask = (1 << (int)UNITY_LAYERS.Obj);
		mouseRay = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		hits = Physics.RaycastAll(mouseRay, mask);
		Array.Sort(hits, CompareDistFromCamera);

		LoggingText.self.text.text = "#: " + hits.Length;
		for (int i = 0; i < hits.Length; i++)
		{
			//MeshRenderer render = hits[i].transform.gameObject.GetComponentInChildren<MeshRenderer>();
			//render.material.color = new Color(render.material.color.r, render.material.color.g, render.material.color.b, 0.3f);
			Obj obj = hits[i].transform.gameObject.GetComponentInParent<Obj>();
			if (obj == null) { continue; }
			LoggingText.self.text.text += "\n" + obj.type + " x: " + obj.x + " y: " + obj.y;

			if (obj.type == Builtins.Tile) { Ghost.Position(obj.transform.position, obj.transform.rotation); break; }
		}

		/* Handle Clicks */
		if (Input.GetMouseButtonDown(0)) { HandleMouseDown(); }
		if (Input.GetMouseButtonUp(0)) { HandleMouseUp(); }
		hits = new RaycastHit[0];
	}

	static void HandleMouseDown()
	{
		for (int i = 0; i < hits.Length; i++)
		{
			mouseUp = true;
			Obj obj = hits[i].transform.gameObject.GetComponentInParent<Obj>();
			if (obj == null) { continue; }

			if (obj.type == Builtins.Tile && Ghost.self.obj.puppet.activeSelf)
			{
				Obj.Create(obj.x, obj.y, Globals.ids++, Ghost.self.obj.facing, Builtins.Conveyor, obj.grid);
				Ghost.self.Deactivate();
				break;
			}
			else
			{
				break;
			}
		}
		if (mouseUp) { Sounds.PlayUI(Sounds.FX.ButtonDown); }
	}

	static bool mouseUp = false;

	static void HandleMouseUp()
	{
		if (mouseUp) { Sounds.PlayUI(Sounds.FX.ButtonUp); mouseUp = false;}
	}
}
