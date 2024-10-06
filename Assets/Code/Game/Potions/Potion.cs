using UnityEngine;

namespace ClearCursesProto.Game
{
    [CreateAssetMenu(fileName = "Potion", menuName = "SO/Potions")]
    public class Potion : ScriptableObject
    {
        public PotionType Type { get { return _type; } }
        public LilFrogCurse AddCurse { get { return _addCurse; } }
        public LilFrogCurse RemoveCurse { get { return _removeCurse; } }

        [SerializeField]
        private PotionType _type;

        [SerializeField]
        private LilFrogCurse _addCurse;

        [SerializeField]
        private LilFrogCurse _removeCurse;
    }
}