using ClearCursesProto.Game;
using UnityEngine;

namespace ClearCursesProto.Controllers
{
    public class PotionAppliedObserver : MonoBehaviour
    {
        [SerializeField]
        private PotionApplier _potionApplier;

        [SerializeField]
        private CurseOrderTracker _curseOrderTracker;

        [SerializeField]
        private PotionFX _potionFX;

        private void OnEnable()
        {
            _potionApplier.OnPotionApplied += ApplyPotion;
        }

        private void OnDisable()
        {
            _potionApplier.OnPotionApplied -= ApplyPotion;
        }

        private void ApplyPotion(Potion potion)
        {
            _curseOrderTracker.OnPotionApplied();
            _potionFX.OnPotionApllied(potion);
        }
    }
}