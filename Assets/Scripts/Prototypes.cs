using System.Collections.Generic;

using TypeInfo;
using Enums;
using Structs;

public static class Prototypes
{
	public static Obj.Prototype Tile()
	{
		Obj.Prototype p;

		p.type = Builtins.Tile;
		p.height = 0f;
		p.layer = GridLayer.Base;
		p.animations = new List<Anim.Animation>();
		Anim.Animation anim = new Anim.Animation();
		anim.type = Builtins.Stand;
		anim.mat = SheetFuncs.Find(Builtins.sheet);
		anim.frames = new List<Anim.Frame>();
		Anim.Frame f;
		f.x = 0;
		f.y = 1;
		f.width = 75;
		f.height = 75;
		f.time = -1;
		anim.frames.Add(f);
		p.animations.Add(anim);
		return p;
	}

	public static Obj.Prototype Conveyor()
	{
		Obj.Prototype p;

		p.type = Builtins.Conveyor;
		p.height = 0.1f;
		p.layer = GridLayer.Conveyor;
		p.animations = new List<Anim.Animation>();
		Anim.Animation anim = new Anim.Animation();
		anim.type = Builtins.Stand;
		anim.mat = SheetFuncs.Find(Builtins.sheet);
		anim.frames = new List<Anim.Frame>();
		Anim.Frame f;
		f.x = 0;
		f.y = 0;
		f.width = 75;
		f.height = 75;
		f.time = -1;
		anim.frames.Add(f);
		p.animations.Add(anim);
		return p;
	}

	public static Obj.Prototype Parcel()
	{
		Obj.Prototype p;
		p.type = Builtins.Parcel;
		p.height = 0.2f;
		p.layer = GridLayer.Top;
		p.animations = new List<Anim.Animation>();
		Anim.Animation anim = new Anim.Animation();
		anim.type = Builtins.Stand;
		anim.mat = SheetFuncs.Find(Builtins.sheet);
		anim.frames = new List<Anim.Frame>();
		Anim.Frame f;
		f.x = 0;
		f.y = 1;
		f.width = 75;
		f.height = 75;
		f.time = -1;
		anim.frames.Add(f);
		p.animations.Add(anim);
		return p;
	}
}
