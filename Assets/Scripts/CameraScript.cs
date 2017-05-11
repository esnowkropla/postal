using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	List<InputResponse> responses = new List<InputResponse>();
	
	void Start ()
	{
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_LEFT_KDOWN, CameraLeft));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_LEFT_KUP, CameraRight));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_RIGHT_KDOWN, CameraRight));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_RIGHT_KUP, CameraLeft));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_FORWARD_KDOWN, CameraForward));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_FORWARD_KUP, CameraBack));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_BACK_KDOWN, CameraBack));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_BACK_KUP, CameraForward));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_ZOOM_IN, ZoomIn));
		responses.Add(new InputResponse(INPUT_EVENT.CAMERA_ZOOM_OUT, ZoomOut));
	}

	void Update ()
	{
		InputManager.FilterInput(responses);

		dx = force.normalized * cameraSpeed * Timer.deltaTime;
		gameObject.transform.position += dx;
	}

	void CameraLeft()
	{
		force += Vector3.left * 10;
	}

	void CameraRight()
	{
		force += Vector3.right * 10;
	}

	void CameraForward()
	{
		force += Vector3.up * 10;
	}

	void CameraBack()
	{
		force += Vector3.down * 10;
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
