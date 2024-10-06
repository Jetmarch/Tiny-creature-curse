using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class PotionFX : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particleSystem;

        private ParticleSystem.MainModule _mainModule;

        [SerializeField]
        private SerializableDictionaryBase<PotionType, Color> _potionColorMap;

        private void Awake()
        {
            _mainModule = _particleSystem.main;
        }

        public void OnPotionApllied(Potion potion)
        {
            _mainModule.startColor = _potionColorMap[potion.Type];
            _particleSystem.Play();
        }
    }
}