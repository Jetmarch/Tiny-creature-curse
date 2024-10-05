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
        private List<PotionButtonUI> _potionButtons = new();

        private void Start()
        {
            foreach(var button in _potionButtons)
            {
                button.OnPotionSelected += PotionButtonClicked;
            }
        }

        private void PotionButtonClicked(Potion potion)
        {
            OnPotionButtonClicked?.Invoke(potion);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _potionButtons.Clear();
            foreach(var potionButton in FindObjectsOfType<PotionButtonUI>())
            {
                _potionButtons.Add(potionButton);
            }
        }
#endif
    }
}
