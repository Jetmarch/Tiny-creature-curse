using RotaryHeart.Lib.SerializableDictionary;
using System.Collections.Generic;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private SerializableDictionaryBase<string, AudioClip> _audioClipMap;


        public void PlaySound(string soundName)
        {
            if(_audioClipMap.TryGetValue(soundName, out AudioClip audioClip))
            {
                AudioSource.PlayClipAtPoint(audioClip, Vector3.one);
            }
        }
    }
}