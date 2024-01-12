using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

	public static AudioManager Instance;

	public void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}


		DontDestroyOnLoad(gameObject);
		foreach (Sound s in sounds)
		{
			s.source =  gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;


			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	private void Start()
	{
		//Play("Theme");
		Play("WindTheme");

	}


	public void Play(string name)
	{
		Sound s =  Array.Find(sounds, Sound => Sound.name == name);

		if (s == null)
		{
			Debug.Log("Sorry sound with name not found");
			return;
		}

		s.source.Play();
	}

	public void Stop(string name)
	{
		Sound s = Array.Find(sounds, Sound => Sound.name == name);

		if (s == null)
		{
			Debug.Log("Sorry sound with name not found");
			return;
		}
	
		s.source.Stop();

		// we are here to do a
	}

}
