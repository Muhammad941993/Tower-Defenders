using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public enum Sound
    {
     BuildingPlaced,
     GameOver,
     EnemyHit,
     EnemyDie,
     BuildingDestroyed,
     BuildingDamaged
    }
    AudioSource audioSource;
    private Dictionary<Sound, AudioClip> soundAudioClipsDictionary = new();

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Instance = this;
        
        foreach (Sound sound in Enum.GetValues(typeof(Sound)))
        {
            soundAudioClipsDictionary[sound] = Resources.Load<AudioClip>(sound.ToString());
        }
    }

    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(soundAudioClipsDictionary[sound]);
    }

}
