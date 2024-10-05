using ClearCursesProto.Game;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ClearCursesProto.UI
{
    public class PotionButtonUI : MonoBehaviour
    {
        public event Action<Potion> OnPotionSelected;

        [SerializeField]
        private Potion _potion;

        [SerializeField]
        private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(OnPotionButtonClick);
        }

        private void OnPotionButtonClick()
        {
            OnPotionSelected?.Invoke(_potion);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _button = GetComponent<Button>();
        }
#endif
    }
}