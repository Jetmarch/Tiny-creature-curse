using ClearCursesProto.Game;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace ClearCursesProto.UI
{
    public class PotionDescriptionStorage : MonoBehaviour
    {
        [SerializeField]
        private SerializableDictionaryBase<PotionType, string> _potionDescription;

        [SerializeField]
        private string _defaultValue = "UNKNOWN";

        public string GetDescription(PotionType potionType)
        {
            if (_potionDescription.TryGetValue(potionType, out var description))
            {
                return description;
            }
            return _defaultValue;
        }
    }
}
