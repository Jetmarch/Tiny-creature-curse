using ClearCursesProto.Game;
using ClearCursesProto.UI;
using UnityEngine;

namespace ClearCursesProto.Controllers
{
    public class PlayAudioObserver : MonoBehaviour
    {
        [SerializeField]
        private AudioManager _audioManager;

        [SerializeField]
        private PotionsPanelView _buttonsManager;

        [SerializeField]
        private PotionApplier _potionApplier;

        [SerializeField]
        private CurseOrderTracker _curseOrderTracker;

        [Header("Sound keys")]
        [SerializeField]
        private string pointerEnterPotion;

        [SerializeField]
        private string potionApplied;

        [SerializeField]
        private string _curseOrderCompleted;

        private void OnEnable()
        {
            _buttonsManager.OnPoinerEnterPotion += OnPointerEnterPotion;
            _potionApplier.OnPotionApplied += OnPotionApplied;
            _curseOrderTracker.OnOrderCompleted += OnCurseOrderCompleted;
        }

        

        private void OnDisable()
        {
            _buttonsManager.OnPoinerEnterPotion -= OnPointerEnterPotion;
            _potionApplier.OnPotionApplied -= OnPotionApplied;
            _curseOrderTracker.OnOrderCompleted -= OnCurseOrderCompleted;
        }

        private void OnPointerEnterPotion()
        {
            _audioManager.PlaySound(pointerEnterPotion);
        }

        private void OnPotionApplied(Potion obj)
        {
            _audioManager.PlaySound(potionApplied);
        }

        private void OnCurseOrderCompleted()
        {
            _audioManager.PlaySound(_curseOrderCompleted);
        }
    }
}