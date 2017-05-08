using UnityEngine;
using System.Collections.Generic;

using TypeInfo;

public static class SheetFuncs
{
	public static List<Mat> materials = new List<Mat>();
	
	public struct Mat
	{
		public Type type;
		public Material material;
	}
}
