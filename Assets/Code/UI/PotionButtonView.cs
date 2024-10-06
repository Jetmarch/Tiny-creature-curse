using ClearCursesProto.Game;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ClearCursesProto.UI
{
    public class PotionButtonView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<Potion> OnPotionSelected;
        public event Action<Potion> OnPointerEnterPotion;
        public event Action OnPointerExitPotion;

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

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterPotion?.Invoke(_potion);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitPotion?.Invoke();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _button = GetComponent<Button>();
        }
#endif
    }
}