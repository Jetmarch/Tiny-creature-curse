using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private SerializableDictionaryBase<string, AudioClip> _audioClipMap;

        [SerializeField]
        private AudioSource _audioSource;

        public void PlaySound(string soundName)
        {
            if(_audioClipMap.TryGetValue(soundName, out AudioClip audioClip))
            {
                _audioSource.clip = audioClip;
                _audioSource.Play();
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _audioSource = GetComponent<AudioSource>();
        }
#endif
    }
}