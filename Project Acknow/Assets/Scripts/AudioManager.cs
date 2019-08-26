﻿using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;
	string MusicName;
	public static AudioManager instance;

	void Awake()
	{

		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		List<string> BackgroundMusic = new List<string>();

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();

			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;

			s.name = MusicName;

			Debug.Log(MusicName);

			//BackgroundMusic.Add(new string(MusicName));
		}
	}

	private void Start()
	{
		Play("Song4");
	}

	public void Play(string name)
	{
		Sound s = System.Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " has not been found. Check spelling.");
			return;

		}
		s.source.Play();

	}

}