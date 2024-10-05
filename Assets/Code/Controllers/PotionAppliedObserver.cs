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

        private void OnEnable()
        {
            _potionApplier.OnPotionApplied += _curseOrderTracker.OnPotionApplied;
        }

        private void OnDisable()
        {
            _potionApplier.OnPotionApplied -= _curseOrderTracker.OnPotionApplied;
        }
    }
}