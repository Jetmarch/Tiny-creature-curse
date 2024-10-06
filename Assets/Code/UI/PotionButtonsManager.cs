using ClearCursesProto.Game;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClearCursesProto.UI
{
    public class PotionButtonsManager : MonoBehaviour
    {
        public event Action<Potion> OnPotionButtonClicked;

        [SerializeField]
        private List<PotionButtonView> _potionButtons = new();

        [SerializeField]
        private TextPopupView _textPopup;

        [SerializeField]
        private PotionDescriptionStorage _descriptionStorage;

        private void Start()
        {
            foreach(var button in _potionButtons)
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
        }

        private void PointerExitPotion()
        {
            _textPopup.HidePopup();
        }

        private void PotionButtonClicked(Potion potion)
        {
            OnPotionButtonClicked?.Invoke(potion);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _potionButtons.Clear();
            foreach(var potionButton in FindObjectsOfType<PotionButtonView>())
            {
                _potionButtons.Add(potionButton);
            }
        }
#endif
    }
}
