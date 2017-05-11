using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Structs;
using Enums;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	RectTransform rect;
	float startedMove = 0f;

	public MenuState state = MenuState.OUT;
	public Vector2 offPosition;
	public Vector2 onPosition;
	public float slideTime;

	List<InputResponse> responses = new List<InputResponse>();
	
	void Start ()
	{
		rect = gameObject.GetComponent<RectTransform>();

		responses.Add(new InputResponse(INPUT_EVENT.TOGGLE_MENU_0, Toggle));
	}
	
	void Update ()
	{
		InputManager.FilterInput(responses);
		HandleMovement();
	}

	void HandleMovement()
	{
		float a = ((Timer.time - startedMove)*Mathf.PI)/(2*slideTime);
		a = a > Mathf.PI/2 ? Mathf.PI/2 : a ;
		float f = Mathf.Sin(a);
		switch (state)
		{
			case MenuState.IN: rect.anchoredPosition = Vector2.Lerp(offPosition, onPosition, f); break; 
			case MenuState.OUT: rect.anchoredPosition = Vector2.Lerp(offPosition, onPosition, 1 - f); break; 
		}
	}

	public void Toggle()
	{
		startedMove = Timer.time;
		state = state == MenuState.OUT ? MenuState.IN : MenuState.OUT;
	}

	public void ToggleEvent()
	{
		InputManager.eventBuffer.Add(new InputEvent(INPUT_EVENT.TOGGLE_MENU_0, null));
	}
}
