using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;
    // Singleton instance.
    public static SoundManager Instance = null;

    private AudioClip nextMusic;
    private double nextStartTime;
    private bool nextQueued;
	
    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad (gameObject);
        nextQueued = false;
    }
    public void Update()
    {
        if (nextQueued && AudioSettings.dspTime >= nextStartTime)
        {
            PlayMusic(nextMusic);
            nextQueued = false;
        }
    }
    
    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    public void Play2Music(AudioClip first, AudioClip second)
    {
        MusicSource.clip = first;
        MusicSource.loop = false;
        nextMusic = second;
        double duration = (double) first.samples / first.frequency;
        nextStartTime = AudioSettings.dspTime + duration;
        nextQueued = true;
        MusicSource.Play();
    }
    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }
    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }
	
}