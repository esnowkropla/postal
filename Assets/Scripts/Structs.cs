using UnityEngine;
using System;

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

	public struct InputResponse
	{
		public InputEvent inputEvent;
		public Action action;

		public InputResponse(INPUT_EVENT e, Action a)
		{
			inputEvent = new InputEvent(e, null);
			action = a;
		}
	}

	#pragma warning disable 0660
	public struct GridLayer
	#pragma warning restore 0660
	{
		public const int Base = 0;
		public const int Conveyor = 1;
		public const int Top = 2;

		int layer;

		public GridLayer(int i)
		{
			layer = i;
		}

		public override Int32 GetHashCode() { return layer; }

		public static bool operator ==(GridLayer a, GridLayer b) { return a.layer == b.layer; }
		public static bool operator !=(GridLayer a, GridLayer b) { return a.layer != b.layer; }

		public static implicit operator int(GridLayer grid)
		{
			return grid.layer;
		}

		public static implicit operator GridLayer(int x)
		{
			GridLayer t;
			t.layer = x;
			return t;
		}
	}

	public struct Pair<T>
	{
		T x;
		T y;
	}
}
