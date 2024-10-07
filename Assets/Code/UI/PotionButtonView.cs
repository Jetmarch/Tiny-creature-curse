using ClearCursesProto.Game;
using DG.Tweening;
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

        [Header("Animations")]
        [SerializeField]
        private float _scaleFactorOnPointerEnter = 1.2f;
        [SerializeField]
        private float _scaleSpeed = 0.2f;

        private Vector3 _startScale;

        private void Start()
        {
            _button.onClick.AddListener(OnPotionButtonClick);
            _startScale = transform.lossyScale;
        }

        private void OnPotionButtonClick()
        {
            OnPotionSelected?.Invoke(_potion);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterPotion?.Invoke(_potion);

            transform.DOScale(_startScale * _scaleFactorOnPointerEnter, _scaleSpeed);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitPotion?.Invoke();

            transform.DOScale(_startScale, _scaleSpeed);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _button = GetComponent<Button>();
        }
#endif
    }
}