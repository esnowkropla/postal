using UnityEngine;
using System.Collections.Generic;

using TypeInfo;

public class Anim : MonoBehaviour
{
	public int currentFrame = 0;
	public float time = 0;
	public Animation currentAnimation = null;
	public SheetFuncs.Mat currentMaterial = default(SheetFuncs.Mat);

	public GameObject puppet;
	public MeshFilter filter;
	public MeshRenderer meshRenderer;

	public List<Animation> animations = null;

	public void Init()
	{

	}

	public void StartAnimation(Animation anim)
	{
		if (anim.mat.type != currentMaterial.type) { meshRenderer.material = anim.mat.material; }
		currentAnimation = anim;
		currentMaterial = anim.mat;

		currentFrame = 0;
		time = Timer.time;
		Frame frame = currentAnimation.frames[0];
		SheetFuncs.SetTexture(frame.x, frame.y, frame.width, frame.height, filter);
	}

	public class Animation
	{
		public Type type;
		public List<Frame> frames;
		public SheetFuncs.Mat mat;
	}
	
	public struct Frame
	{
		public int x;
		public int y;
		public int width;
		public int height;
		public float time;
	}
}
