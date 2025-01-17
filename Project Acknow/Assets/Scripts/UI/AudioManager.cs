﻿using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    float volume = 1f;

    AudioMixerGroup GeneralMixer;

    public Sound[] sounds;
	string MusicName;
	public static AudioManager instance;

	[HideInInspector]
	public List<string> BackgroundMusic = new List<string>();


	int IndexPlaying;

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

		

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();

			s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.MixerGroup;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;

			MusicName = s.name;

			BackgroundMusic.Add(MusicName);
		}
	}

    public void Volume(float InVolume)
    {
        //Debug.Log(InVolume);
        GeneralMixer.audioMixer.SetFloat("GeneralVol", Mathf.Log10(InVolume) * 20);
        volume = InVolume;
    }
     
    public void RePopulate(AudioMixerGroup audioMixerGroup, Slider slider)
	{
		FindObjectOfType<GameMangaer>().PopulateList(BackgroundMusic);
        GeneralMixer = audioMixerGroup;
        slider.value = volume;
	}

	public void Start()
	{

		FindObjectOfType<GameMangaer>().PopulateList(BackgroundMusic);

		Play(BackgroundMusic[1]);
		IndexPlaying = 1;
	}

	public void PlayDropdown(int index)
	{
		Stop(BackgroundMusic[IndexPlaying]);
		Play(BackgroundMusic[index]);
		IndexPlaying = index;
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

	public void Stop(string name)
	{
		Sound s = System.Array.Find(sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " has not been found. Check spelling.");
			return;

		}
		s.source.Stop();

	}

}