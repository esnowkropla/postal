namespace Enums
{
	public enum INPUT_EVENT
	{
		NONE,
		CAMERA_LEFT_KUP,
		CAMERA_LEFT_KDOWN,
		CAMERA_RIGHT_KUP,
		CAMERA_RIGHT_KDOWN,
		CAMERA_FORWARD_KUP,
		CAMERA_FORWARD_KDOWN,
		CAMERA_BACK_KUP,
		CAMERA_BACK_KDOWN,
		CAMERA_ZOOM_IN,
		CAMERA_ZOOM_OUT,
		ROTATE_CLOCKWISE,
		ROTATE_COUNTER_CLOCKWISE,
		TOGGLE_MENU_0
	}

	public enum UNITY_LAYERS
	{
		None = 0,
		UI = 5,
		Obj = 8
	}

	public enum Facing
	{
		Right = 0,
		Down = 1,
		Left = 2,
		Up = 3
	}

	public enum MenuState
	{
		IN,
		OUT
	}
}
