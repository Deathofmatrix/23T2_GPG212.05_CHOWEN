using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace EasyAudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager instance;


        [HideInInspector] public Sound mainStart;
        private Sound mainLoop;
        private Sound deathScreen;

        private void Awake()
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

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log($"Sound: {name} not found!");
                return;
            }

            s.source.Play();
        }

        public void Pause(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log($"Sound: {name} not found!");
                return;
            }

            s.source.Pause();
        }

        private void Start()
        {
            Play("MainTheme");
        }

        private void OnLevelWasLoaded(int level)
        {
            Sound s = Array.Find(sounds, sound => sound.name == "MainTheme");
            if (s.source.isPlaying == false)
            {
                s.source.time = 0;
                Play("MainTheme");
            }
        }
    }
}