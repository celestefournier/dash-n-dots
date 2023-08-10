using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioSource MusicSource;
        [SerializeField] AudioSource SoundFxSource;
        [SerializeField] List<SoundEffectClip> SoundEffects;

        public static AudioManager Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            SetMusicSettings(PlayerPrefs.GetInt("musicOn", 1) == 1);
            SetSoundSettings(PlayerPrefs.GetInt("soundFxOn", 1) == 1);
        }

        public void SetSoundSettings(bool active)
        {
            SoundFxSource.enabled = active;
            PlayerPrefs.SetInt("soundFxOn", active ? 1 : 0);
        }

        public void SetMusicSettings(bool active)
        {
            MusicSource.enabled = active;
            PlayerPrefs.SetInt("musicOn", active ? 1 : 0);
        }

        public void PlaySound(SoundEffect sfx)
        {
            if (!SoundFxSource.enabled)
                return;

            var soundEffect = SoundEffects.Find(e => e.SoundEffect == sfx).AudioClip;
            SoundFxSource.PlayOneShot(soundEffect);
        }

        [Serializable]
        private class SoundEffectClip
        {
            public SoundEffect SoundEffect;
            public AudioClip AudioClip;
        }
    }

    public enum SoundEffect
    {
        Select,
        Score
    }
}