using UnityEngine;

namespace RainesGames.Audio
{
    public class GlobalSoundEffectManager : MonoBehaviour
    {
        private static AudioSource _audioSource;
        public static AudioSource AudioSource => _audioSource;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public static void Play(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}