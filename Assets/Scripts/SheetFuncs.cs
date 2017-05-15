using UnityEngine;
using System.IO;
using System.Collections.Generic;

using TypeInfo;

public static class SheetFuncs
{
	public static List<Mat> materials = new List<Mat>();
	public const int pxWidth = 1024;
	
	public struct Mat
	{
		public Type type;
		public Material material;
	}

	public static Mat Find(Type type)
	{
		for (int i = 0; i < materials.Count; i++)
		{
			if (materials[i].type == type) { return materials[i]; }
		}
		Logging.Error("Could not find material with type " + type);
		return default(Mat);
	}

	public static void LoadSheets()
	{
		if (!Directory.Exists(Globals.persistentPath+"postal_base/Sheets"))
		{
			Directory.CreateDirectory(Globals.persistentPath+"postal_base/Sheets");
		}

		string path = Globals.assetPath + "postal_base/Sheets/";
		string[] sheetFiles = Directory.GetFiles(path, "*png");
		for (int i = 0; i < sheetFiles.Length; i++)
		{
			string sheetName = sheetFiles[i];
			WWW www = new WWW("file://" + sheetName);

			Texture newTex = www.texture;
			newTex.filterMode = FilterMode.Trilinear;

			Material newMat = new Material(Shader.Find("Custom/Texture_Alpha"));
			newMat.mainTexture = newTex;

			Mat mat;
			mat.type = Utility.FileToName(sheetName);
			mat.material = newMat;
			materials.Add(mat);
			Logging.Log("Added sprint sheet: \"" + mat.type + "\"");
		}
	}

	public static Vector2[] newUVs = new Vector2[4];
	public static void SetTexture(int x, int y, int width, int height, MeshFilter filter)
	{
		/* Unity Quad Lables
		 * 3 -- 1
		 * |	|
		 * 0 -- 2
		 */

		float cut = 0.00005f;

		float origin_x = (float)x * width;
		float origin_y = pxWidth - ((float)y + 1) * height;

		newUVs[0].x = origin_x / pxWidth;
		newUVs[0].y = origin_y / pxWidth;

		newUVs[1].x = (origin_x + width) / pxWidth;
		newUVs[1].y = (origin_y + height) / pxWidth;

		newUVs[2].x = (origin_x + width) / pxWidth;
		newUVs[2].y = origin_y / pxWidth;

		newUVs[3].x = origin_x / pxWidth;
		newUVs[3].y = (origin_y + height) / pxWidth;

		//This fixes that texture overlapping problem. It cuts a tiny tiny amount of the all of the edges of the texture.
		newUVs[0].x += cut;
		newUVs[0].y += cut;
		newUVs[1].x -= cut;
		newUVs[1].y -= cut;
		newUVs[2].x -= cut;
		newUVs[2].y += cut;
		newUVs[3].x += cut;
		newUVs[3].y -= cut;

		Mesh mesh = filter.mesh;
		mesh.uv = newUVs;
	}
}
