using UnityEngine;
using Enums;

namespace Structs
{
	public struct InputEvent
	{
		public INPUT_EVENT type;
		public GameObject target;

		public InputEvent(INPUT_EVENT t, GameObject g)
		{
			type = t;
			target = g;
		}
	}
}
