using System;
using UnityEngine;

namespace ClearCursesProto.Game
{
    public class PotionApplier : MonoBehaviour
    {
        public event Action<Potion> OnPotionApplied;

        [SerializeField]
        private Creature _currentCreature;

        private void Start()
        {
            _currentCreature.UpdateCurses();
        }

        public void ApplyPotion(Potion potion)
        {
            _currentCreature.AddCurse(potion.AddCurse);
            _currentCreature.RemoveCurse(potion.RemoveCurse);
            _currentCreature.UpdateCurses();

            OnPotionApplied?.Invoke(potion);
        }
    }
}