using UnityEngine;
using System.Collections;

using Structs;
using Enums;

public class CameraScript : MonoBehaviour
{
	const float cameraSpeed = 10;

	enum ZOOM
	{
		FAR,
		MIDDLE,
		NEAR
	}

	ZOOM zoomLevel = ZOOM.FAR;
	int[] zooms = {-10, -7, -5};

	Vector3 force;
	Vector3 dx;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (InputManager.eventBuffer.Count > 0)
		{
			InputEvent input = InputManager.eventBuffer.PopFront();
			switch(input.type)
			{
				case INPUT_EVENT.CAMERA_LEFT_KDOWN: force += Vector3.left * 10; break;
				case INPUT_EVENT.CAMERA_LEFT_KUP: force += Vector3.right * 10; break;
				case INPUT_EVENT.CAMERA_RIGHT_KDOWN: force += Vector3.right * 10; break;
				case INPUT_EVENT.CAMERA_RIGHT_KUP: force += Vector3.left * 10; break;
				case INPUT_EVENT.CAMERA_FORWARD_KDOWN: force += Vector3.up * 10; break;
				case INPUT_EVENT.CAMERA_FORWARD_KUP: force += Vector3.down * 10; break;
				case INPUT_EVENT.CAMERA_BACK_KDOWN: force += Vector3.down * 10; break;
				case INPUT_EVENT.CAMERA_BACK_KUP: force += Vector3.up * 10; break;
				case INPUT_EVENT.CAMERA_ZOOM_IN: ZoomIn(); break;
				case INPUT_EVENT.CAMERA_ZOOM_OUT: ZoomOut(); break;
				default: InputManager.eventBuffer.Add(input); break;
			}
		}

		dx = force.normalized * cameraSpeed * Timer.deltaTime;
		gameObject.transform.position += dx;
	}

	void ZoomIn()
	{
		if ((int) zoomLevel < 2)
		{
			zoomLevel = (ZOOM)(((int)zoomLevel) + 1);
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zooms[(int)zoomLevel]);
		}
	}

	void ZoomOut()
	{
		if ((int) zoomLevel > 0)
		{
			zoomLevel = (ZOOM)(((int)zoomLevel) - 1);
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zooms[(int)zoomLevel]);
		}
	}
}
