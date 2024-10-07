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

        [SerializeField]
        private MouseClickOnObject _frogClicker;

        [Header("Sound keys")]
        [SerializeField]
        private string pointerEnterPotion;

        [SerializeField]
        private string potionApplied;

        [SerializeField]
        private string _curseOrderCompleted;

        [SerializeField]
        private string _frogCroak;

        [SerializeField]
        private string _completeGame;

        private void OnEnable()
        {
            _buttonsManager.OnPoinerEnterPotion += OnPointerEnterPotion;
            _potionApplier.OnPotionApplied += OnPotionApplied;
            _curseOrderTracker.OnOrderCompleted += OnCurseOrderCompleted;
            _frogClicker.OnClick += OnLilFrogClick;
            _curseOrderTracker.OnCompleteGame += OnCompleteGame;
        }

        private void OnDisable()
        {
            _buttonsManager.OnPoinerEnterPotion -= OnPointerEnterPotion;
            _potionApplier.OnPotionApplied -= OnPotionApplied;
            _curseOrderTracker.OnOrderCompleted -= OnCurseOrderCompleted;
            _frogClicker.OnClick -= OnLilFrogClick;
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

        private void OnLilFrogClick()
        {
            //_audioManager.PlaySound(_frogCroak);
        }

        private void OnCompleteGame()
        {
            _audioManager.PlaySound(_completeGame);
        }

    }
}