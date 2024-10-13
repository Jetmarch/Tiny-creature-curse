using ClearCursesProto.Game;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClearCursesProto.UI
{
    public class PotionsPanelView : MonoBehaviour
    {
        public event Action<Potion> OnPotionButtonClicked;
        public event Action OnPoinerEnterPotion;
        public event Action OnPoinerExitPotion;

        [SerializeField]
        private List<PotionButtonView> _potionButtons = new();

        [SerializeField]
        private GameObject _view;

        [SerializeField]
        private TextPopupView _textPopup;

        [SerializeField]
        private PotionDescriptionStorage _descriptionStorage;

        public void Show()
        {
            _view.SetActive(true);
            _textPopup.HidePopup();
        }

        public void Hide()
        {
            _view.SetActive(false);
            _textPopup.HidePopup();
        }

        private void Start()
        {
            foreach (var button in _potionButtons)
            {
                button.OnPotionSelected += PotionButtonClicked;
                button.OnPointerEnterPotion += PointerEnterPotion;
                button.OnPointerExitPotion += PointerExitPotion;
            }

            _textPopup.HidePopup();
        }

        private void PointerEnterPotion(Potion potion)
        {
            var potionDescription = _descriptionStorage.GetDescription(potion.Type);
            _textPopup.ShowPopup(potionDescription);
            OnPoinerEnterPotion?.Invoke();
        }

        private void PointerExitPotion()
        {
            _textPopup.HidePopup();
            OnPoinerExitPotion?.Invoke();
        }

        private void PotionButtonClicked(Potion potion)
        {
            OnPotionButtonClicked?.Invoke(potion);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _potionButtons.Clear();
            foreach (var potionButton in FindObjectsOfType<PotionButtonView>())
            {
                _potionButtons.Add(potionButton);
            }
        }
#endif
    }
}
