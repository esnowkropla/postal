using UnityEngine;

public class Sounds : MonoBehaviour
{
	public static Sounds self;
	public AudioClip buttonDown;
	public AudioClip buttonUp;
	public AudioSource src;

	public enum FX
	{
		ButtonDown,
		ButtonUp
	}

	public void Start()
	{
		self = this;
		Object.DontDestroyOnLoad(this);
	}

	public static void PlayUI(FX fx)
	{
		self.src.volume = 1;//The "1" is a local volume, which could be hooked up to a per sound effect variable.
		
		switch (fx)
		{
			case FX.ButtonDown: self.src.clip = self.buttonDown; break;
			case FX.ButtonUp: self.src.clip = self.buttonUp; break;
		}

		//FUCK = src.clip.loadState;//Stuff is silent, if we take out the debug logs or this FUCK thing. 

		//DestroyAfterPlayingSnd script = go.AddComponent<DestroyAfterPlayingSnd>();
		//script.delay = src.clip.length + 1;
		//script.timeSet = xa.time;
		self.src.Play();
	}
}
